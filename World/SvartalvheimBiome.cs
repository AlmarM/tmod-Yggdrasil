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
    //public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("Yggdrasil/SvartalvheimBiomeBackgroundStyle");

    public override int Music => MusicID.OtherworldlyIce;

    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

    public override string BestiaryIcon => ("Yggdrasil/Assets/Textures/SvartalvheimBiome/SvartalvheimBiome_Icon");
    public override string BackgroundPath => base.BackgroundPath;
    public override Color? BackgroundColor => base.BackgroundColor;

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

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalvheim");
    }
}