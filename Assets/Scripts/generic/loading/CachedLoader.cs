﻿using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CachedLoader : ILoader {
    private WWWLoader loader = new WWWLoader();
    private static readonly string WWW_PREFIX = "file:///";
	public static readonly string SERVER_PATH = "https://s3.amazonaws.com/crhc/";
	//public static readonly string SERVER_PATH = "http://chrc.s3-website.us-east-2.amazonaws.com/";
    //private static readonly string SERVER_PATH = "http://www3.nd.edu/~rmcgrai1/CRHC/";

	public override IEnumerator loadCoroutine<T>(Reference<T> reference, string path, bool forceReload) {
        IFileManager iFileManager = ServiceLocator.getIFileManager();

        bool fromCache = false;
        string relePath = convertWebToLocalPath(path, PathType.RELATIVE), wwwPath = convertWebToLocalPath(path, PathType.WWW);

        // Check if file already exists in local file storage cache.
		if (relePath != null) {
            ServiceLocator.getILog().print(LogType.IO, "Checking for file at " + relePath + "...");

            if (!forceReload && iFileManager.fileExists(relePath)) {
                fromCache = true;
                path = wwwPath;
                ServiceLocator.getILog().println(LogType.IO, "Using cache!");
            }
            else {
                fromCache = false;
                ServiceLocator.getILog().println(LogType.IO, "Not in cache.");
            }
        }
        else {
            fromCache = true;
        }

        yield return loader.loadCoroutine(reference, path);

        // Backup file in cache if not from there.
        if (!fromCache) {
            ServiceLocator.getILog().println(LogType.IO, "Backing up " + typeof(T) + " at " + relePath + "...");
            reference.save(relePath);
        }
    }

    public static string convertWebToLocalPath(string path, PathType type) {
        // Check if file already exists in local file storage cache.
        bool isHTTP, isWWW;

        if (isHTTP = path.StartsWith("http://")) {
            path = path.Substring(7);
        }
        else if (isHTTP = path.StartsWith("https://")) {
            path = path.Substring(8);
        }
        if (isWWW = path.StartsWith("www.")) {
            path = path.Substring(4);
        }
        else if (isWWW = path.StartsWith("www3.")) {
            path = path.Substring(5);
        }

        // If path leads to a website, then convert cache path to a relevant file path!
        if (isHTTP || isWWW) {
            // TODO: Change to double-dashes for certain devices?
            path = "cache/" + path;

            string cwd = ServiceLocator.getIFileManager().getBaseDirectory();

            if (type == PathType.ABSOLUTE) {
                path = cwd + path;
            }
            else if (type == PathType.WWW) {
                path = WWW_PREFIX + cwd + path;
            }

            return path;
        }

        return null;
    }

    public override void clearCache(bool hardClear) {
        base.clearCache(hardClear);

        if (hardClear) {
            IFileManager iFileManager = ServiceLocator.getIFileManager();
            iFileManager.deleteDirectory(iFileManager.getBaseDirectory() + "cache/");
        }
    }
}

public enum PathType {
    WWW, RELATIVE, ABSOLUTE
}