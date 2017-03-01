﻿using generic;
using System;
using UnityEngine;

public class ImageItem : IItem {
    private Reference<Texture2D> texture;
    private AspectType aspectType;

    public ImageItem(string imageUrl) {
        texture = ServiceLocator.getILoader().load<Texture2D>(imageUrl);
        aspectType = AspectType.CROP_IN_SQUARE;
    }

    public override bool draw(float w, float h) {
        Texture2D tex = texture.getResource();
        float aspect;

        if (tex != null) {
            aspect = 1f * tex.width / tex.height;
        }
        else {
            aspect = 1;
        }


        Rect rect;

        if (aspectType == AspectType.FIT_TO_SQUARE) {
            float x = 0, y = 0;

            GUIX.fillRect(new Rect(0, 0, w, w), CRHC.COLOR_GRAY_DARK);

            if (aspect < 1) {
                x = w / 2;
                w = h * aspect;
                x -= w / 2;
            }
            else {
                y = h / 2;
                h = w / aspect;
                y -= h / 2;
            }

            rect = new Rect(x, y, w, h);
        }
        else if (aspectType == AspectType.CROP_IN_SQUARE) {
            float x = 0, y = 0;

            if (aspect > 1) {
                x = w / 2;
                w = h * aspect;
                x -= w / 2;
            }
            else {
                y = h / 2;
                h = w / aspect;
                y -= h / 2;
            }

            rect = new Rect(x, y, w, h);
        }
        else {
            rect = new Rect(0, 0, w, h);
        }

        if (tex != null) {
            GUIX.Texture(rect, tex);
        }
        else {
            GUIX.beginOpacity(.5f);
            GUIX.strokeRect(rect, CRHC.COLOR_GRAY_DARK, 1);
            GUIX.fillRect(new Rect(0, 0, w * texture.getLoadFraction(), h), CRHC.COLOR_GRAY_DARK);
            GUIX.endOpacity();
        }

        if (GUIX.isMouseInsideRect(rect)) {
            onClick();
            return true;
        }
        else {
            return false;
        }

        return false;
    }

    public override float getHeight(float w) {
        Texture2D tex = texture.getResource();

        if (aspectType == AspectType.HEIGHT_DEPENDENT_ON_WIDTH) {
            float h = w;
            if (tex != null) {
                float texW, texH;
                texW = tex.width;
                texH = tex.height;

                h = w / texW * texH;
            }

            return h;
        }
        else {
            return w;
        }
    }

    public override void onDispose() {
        texture.removeOwner();
    }

    public void setAspectType(AspectType aspectType) {
        this.aspectType = aspectType;
    }
}

public enum AspectType {
    HEIGHT_DEPENDENT_ON_WIDTH, PERFECT_SQUARE, FIT_TO_SQUARE, CROP_IN_SQUARE
}
