using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class DwarfSpiritBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<DwarfSpiritBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        DisplayName.SetDefault("Dwarf Spirit Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Dwarf Spirit");
    }
}