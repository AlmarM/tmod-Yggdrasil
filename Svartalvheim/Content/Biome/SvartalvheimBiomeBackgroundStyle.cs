using Terraria.ModLoader;

namespace Yggdrasil.Svartalvheim.Content.Biome;

public class SvartalvheimBiomeBackgroundStyle : ModUndergroundBackgroundStyle
{
    private const string BiomeAssetPath =
        "Assets/Content/Textures/SvartalvheimBiome/Backgrounds/SvartalvheimUnderground";

    public override void FillTextureArray(int[] textureSlots)
    {
        textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Mod, $"{BiomeAssetPath}0");
        textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot(Mod, $"{BiomeAssetPath}1");
        textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot(Mod, $"{BiomeAssetPath}2");
        textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot(Mod, $"{BiomeAssetPath}3");
    }
}