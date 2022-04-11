using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Items;

public abstract class YggdrasilItem : ModItem
{
    public override string Texture
    {
        get
        {
            string basePath = base.Texture;
            List<string> baseFolders = basePath.Split('/').ToList();
            string[] configFolders = GlobalConfig.RootAssetPath.Split('/');

            for (var i = configFolders.Length - 1; i >= 0; i--)
            {
                baseFolders.Insert(1, configFolders[i]);
            }

            return string.Join("/", baseFolders);
        }
    }
}