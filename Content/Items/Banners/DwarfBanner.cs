using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class DwarfBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<DwarfBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Dwarf Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Dwarves");
    }
}