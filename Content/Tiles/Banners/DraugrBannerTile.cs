using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Snow;

namespace Yggdrasil.Content.Tiles.Banners;

public class DraugrBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<DraugrBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<Draugr>(), ModContent.NPCType<DraugrElite>() };

    protected override string MapEntryName => "Draugr Banner";

    protected override Color MapEntryColor => new(29, 240, 255);
}