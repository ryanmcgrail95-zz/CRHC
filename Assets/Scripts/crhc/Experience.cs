﻿using Newtonsoft.Json.Linq;
using System.Collections;
using UnityEngine;

public class Experience : CrhcItem {
    private Reference<Texture2D> img, outline, overlay;

    public Experience(CrhcItem parent, JObject data) : base(parent, data) {
    }

    public override void onDispose() {
    }

    public void onLandmarkLoad() {
        ILoader loader = ServiceLocator.getILoader();
        img = loader.load<Texture2D>(getUrl() + "image.jpg");
        outline = loader.load<Texture2D>(getUrl() + "outline.png");
        overlay = loader.load<Texture2D>(getUrl() + "overlay.png");
    }

    public void onLandmarkUnload() {
        img.removeOwner();
        outline.removeOwner();
        overlay.removeOwner();
        img = outline = overlay = null;
    }

    public Reference<Texture2D> getImg() {
        return img;
    }
    public Reference<Texture2D> getOutline() {
        return outline;
    }
    public Reference<Texture2D> getOverlay() {
        return overlay;
    }

    public Landmark getLandmark() {
        return getParent() as Landmark;
    }

    public string getTargetId() {
        return getData<string>("targetId");
    }

    public string getSource() {
        return getData<string>("source");
    }

    protected override IEnumerator tryLoad() {
        Menu menu = new Menu();

        Row backRow = new Row();
        backRow.addItem(new Landmark.BackButton(this));
        menu.addRow(backRow);

        //AppRunner.enterMenu(new VuforiaMenu(new BlackoutTransitionMenu(menu, CRHC.SPEED_FADE_IN), this));
        AppRunner.enterMenu(new VuforiaMenu(menu, this));
        yield return null;
    }

    protected override IEnumerator tryUnload() {
        AppRunner.exitMenu();

        yield return null;
    }
}