﻿using generic;
using generic.mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;

public static class GUIX {
    private static Stack<Rect> clipStack;

    private static Stack<Color> colorStack;

    private static Texture2D whiteTexture;
    private static GUIStyle whiteTextureStyle, standardTextureStyle;

    private static Color color;

    static GUIX() {
        clipStack = new Stack<Rect>();

        whiteTexture = new Texture2D(1, 1);
        whiteTexture.SetPixel(0, 0, Color.white);
        whiteTexture.Apply();

        whiteTextureStyle = new GUIStyle();
        whiteTextureStyle.normal.background = whiteTexture;

        standardTextureStyle = new GUIStyle();

        colorStack = new Stack<Color>();
        colorStack.Push(Color.white);
    }

    // Note that this function is only meant to be called from OnGUI() functions.
    public static void strokeRect(Rect position, float thickness) {
        thickness /= 2;

        float x = position.x, y = position.y, w = position.width, h = position.height;

        fillRect(new Rect(x - thickness, y - thickness, w + 2 * thickness, 2 * thickness));
        fillRect(new Rect(x - thickness, y + h - thickness, w + 2 * thickness, 2 * thickness));
        fillRect(new Rect(x - thickness, y - thickness, 2 * thickness, h + 2 * thickness));
        fillRect(new Rect(x + w - thickness, y - thickness, 2 * thickness, h + 2 * thickness));
    }
    public static void strokeRect(Rect position, Color color, float thickness) {
        if (color == CRHC.COLOR_TRANSPARENT) {
            return;
        }

        beginColor(color);
        strokeRect(position, thickness);
        endColor();
    }

    public static void fillRect(Rect region) {
        GUI.Box(region, GUIContent.none, whiteTextureStyle);
    }
    public static void fillRect(Rect position, Color color) {
        if (color == CRHC.COLOR_TRANSPARENT) {
            return;
        }

        beginColor(color);
        fillRect(position);
        endColor();
    }

    private static void setColor(Color color) {
        //GUI.contentColor = color;
        GUIX.color = GUI.backgroundColor = color;
    }

    public static void beginColor(Color toColor) {
        Color fromColor = colorStack.Peek();

        /*float nf = 1 - f;

        float fr = fromColor.r, fg = fromColor.g, fb = fromColor.b, fa = fromColor.a;
        float tr = toColor.r, tg = toColor.g, tb = toColor.b, ta = toColor.a;
        float
            r = (float)Math.Sqrt(fr * fr * nf + tr * tr * f),
            g = (float)Math.Sqrt(fg * fg * nf + tg * tg * f),
            b = (float)Math.Sqrt(fb * fb * nf + tb * tb * f),
            a = (float)Math.Sqrt(fa * fa * nf + ta * ta * f);

        colorStack.Push(new Color(r, g, b, a));*/

        /*float f, nf;
        f = .5f;
        nf = 1 - f;

        float fr = fromColor.r, fg = fromColor.g, fb = fromColor.b, fa = fromColor.a;
        float tr = toColor.r, tg = toColor.g, tb = toColor.b, ta = toColor.a;
        float r, g, b, a;
            r = (float)Math.Sqrt(fr * fr * nf + tr * tr * f),
            g = (float)Math.Sqrt(fg * fg * nf + tg * tg * f),
            b = (float)Math.Sqrt(fb * fb * nf + tb * tb * f),
            a = (float)Math.Sqrt(fa * fa * nf + ta * ta * f);
        r = fr * nf + tr * f;
        g = fg * nf + tg * f;
        b = fb * nf + tb * f;
        a = fa * nf + ta * f;

        colorStack.Push(new Color(r, g, b, a));*/

        toColor.a *= fromColor.a;

        setColor(toColor);
        colorStack.Push(toColor);
    }

    public static void endColor() {
        if (colorStack.Count > 1) {
            colorStack.Pop();
            setColor(colorStack.Peek());
        }
    }

    public static void beginOpacity(float opacity) {
        Color opColor = colorStack.Peek();
        opColor.a *= opacity;

        setColor(opColor);
        colorStack.Push(opColor);
    }

    public static void endOpacity() {
        endColor();
    }

    public static void Button(Rect position, GUIContent content) {
        GUI.Button(position, content);
    }

    public static void Texture(Rect region, Texture2D tex) {
        standardTextureStyle.normal.background = tex;
        GUI.Box(region, GUIContent.none, standardTextureStyle);
    }

    public static void Label(Rect position, GUIContent content, GUIStyle style) {
        GUI.Label(position, content, style);
    }


    public static bool isTouchInsideRect(Rect position) {

        ITouch iTouch = ServiceLocator.getITouch();

        Rect acc = new Rect(getClipRect().position + position.position, position.size);
        return acc.Contains(iTouch.getTouchPosition());
    }

    public static bool didTapInsideRect(Rect position) {

        ITouch iTouch = ServiceLocator.getITouch();

        if (iTouch.checkTap()) {
            return isTouchInsideRect(position);
        }
        else {
            return false;
        }
    }

    private static Rect fixRect(Rect inRect) {
        float x, y, width, height;
        x = inRect.x;
        y = inRect.y;
        width = inRect.width;
        height = inRect.height;

        if (width < 0) {
            x += width;
            width = -width;
        }
        if (height < 0) {
            y += height;
            height = -height;
        }

        return new Rect(x, y, width, height);
    }

    public static void beginClip(Rect position) {
        beginClip(position, Vector2.zero);
    }

    public static void beginClip(Rect newClipRect, Vector2 scrollPosition) {
        newClipRect = fixRect(newClipRect);
        GUI.BeginClip(newClipRect, scrollPosition, Vector2.zero, false);

        Rect currentClipRect = getClipRect();
        if (currentClipRect == null) {
            currentClipRect = new Rect(0, 0, Screen.width, Screen.height);
        }

        newClipRect.position += currentClipRect.position;
        newClipRect.position += scrollPosition;

        newClipRect.size = Vector2.Max(Vector2.zero, Vector2.Min(newClipRect.size, newClipRect.size - (currentClipRect.size - newClipRect.position)));

        clipStack.Push(newClipRect);
    }

    public static void endClip() {
        if (clipStack.Count > 0) {
            clipStack.Pop();
            GUI.EndClip();
        }
    }

    public static Rect getClipRect() {
        return (clipStack.Count > 0) ? clipStack.Peek() : default(Rect);
    }
}
