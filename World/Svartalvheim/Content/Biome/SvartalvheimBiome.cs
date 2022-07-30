using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.World.Svartalvheim.Content.Biome;

public class SvartalvheimBiome : ModBiome
{
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle =>
        ModContent.Find<ModUndergroundBackgroundStyle>("Yggdrasil/SvartalvheimBiomeBackgroundStyle");

    public override int Music => MusicID.OtherworldlyIce;

    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

    public override string BestiaryIcon => "Yggdrasil/Assets/World/Svartalvheim/Textures/Icons/SvartalvheimBiome_Icon";
    // public override string BackgroundPath => base.BackgroundPath;
    // public override Color? BackgroundColor => base.BackgroundColor;

    public override bool IsBiomeActive(Player player)
    {
        YggdrasilPlayer yggdrasilPlayer = player.GetYggdrasilPlayer();
        var isBiomeActive = YggdrasilWorld.SvartalvheimTiles > 7000;

        yggdrasilPlayer.ZoneSvartalvheim = isBiomeActive;

        return isBiomeActive;
    }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalvheim");
    }
}