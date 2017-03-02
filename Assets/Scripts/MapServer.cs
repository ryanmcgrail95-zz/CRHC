﻿using UnityEngine;

public class MapServer {
    public static string BASE_URL = CachedLoader.SERVER_PATH + "map/";

    public static void showRoute(double latitude, double longitude) {
        string url = BASE_URL + "?lng=" + longitude + "&lat=" + latitude;
        Application.OpenURL(url);
    }
}