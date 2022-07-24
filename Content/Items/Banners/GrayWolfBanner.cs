using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class GrayWolfBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<GrayWolfBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("GrayWolf Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Gray Wolf");
    }
}