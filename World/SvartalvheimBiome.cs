using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.World;

public class SvartalvheimBiome : ModBiome
{
    public override bool IsBiomeActive(Player player)
    {
        var RunePlayer = Main.LocalPlayer.GetModPlayer<RunePlayer>();
        if (YggdrasilWorld.SvartalvheimTiles > 7000)
        {         
            //Main.NewText("In Svartalvheim");
            RunePlayer.ZoneSvartalvheim = true;
            return true;
        }
        //Main.NewText("NOT in Svartalvheim");
        RunePlayer.ZoneSvartalvheim = false;
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
        var RunePlayer = Main.LocalPlayer.GetModPlayer<RunePlayer>();
        return RunePlayer.ZoneSvartalvheim;
    }

    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
}