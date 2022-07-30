using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Night;
using Yggdrasil.Content.NPCs.Vikings;

namespace Yggdrasil.Content.Tiles.Banners;

public class VikingBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<VikingBanner>();

    protected override int[] NpcTypes => new[]
    {
        ModContent.NPCType<VikingSwordMan>(),
        ModContent.NPCType<VikingAxeMan>(),
        ModContent.NPCType<VikingArcher>(),
        ModContent.NPCType<FemaleVikingArcher>(),
        ModContent.NPCType<VikingSpearman>(),
        ModContent.NPCType<VikingShieldMaiden>(),
        ModContent.NPCType<Zomviking>()
    };

    protected override string MapEntryName => "Viking Banner";

    protected override Color MapEntryColor => new(88, 83, 97);
}