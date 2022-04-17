using System;
using System.Collections.Generic;
using System.Linq;
using Yggdrasil.Configs;

namespace Yggdrasil.Utils;

public static class TextureUtils
{
    public static string GetAssetPath(Type type)
    {
        string bathPath = (type.Namespace + "." + type.Name).Replace('.', '/');
        IList<string> baseFolders = bathPath.Split('/').ToList();
        string[] configFolders = GlobalConfig.RootAssetPath.Split('/');

        for (var i = configFolders.Length - 1; i >= 0; i--)
        {
            baseFolders.Insert(1, configFolders[i]);
        }

        return string.Join("/", baseFolders);
    }
}