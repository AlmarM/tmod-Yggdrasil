using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Vikings;

namespace Yggdrasil.Content.Tiles.Banners;

public class BerserkerBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<BerserkerBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<Berserker>() };

    protected override string MapEntryName => "Berserker Banner";

    protected override Color MapEntryColor => new(162, 138, 115);
}