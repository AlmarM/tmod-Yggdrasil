using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.World;

public class IronWoodBiome : ModBiome
{
    public override bool IsBiomeActive(Player player)
    {

        if (YggdrasilWorld.IronWoodTiles > 1200)
        {
            YggdrasilWorld.ZoneIronWood = true;
            return true;
        }

        YggdrasilWorld.ZoneIronWood = false;
        return false;
    }
}

public class IronWoodBiomeEffect : ModSceneEffect
{
    public override int Music => MusicID.OtherworldlyIce;

    //public override virtual ModSurfaceBackgroundStyle =>

    //public override void SpecialVisuals(Player player)
    //{

    //}

    public override bool IsSceneEffectActive(Player player)
    {
        return YggdrasilWorld.ZoneIronWood;
    }

    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
}