using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class DraugrBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<DraugrBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Draugr Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Draugr");
    }
}