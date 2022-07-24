using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Vikings;

namespace Yggdrasil.Content.Tiles.Banners;

public class GrayWolfBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<GrayWolfBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<GrayWolf>() };

    protected override string MapEntryName => "Gray Wolf Banner";

    protected override Color MapEntryColor => new(100, 100, 100);
}