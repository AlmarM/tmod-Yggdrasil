using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class BerserkerBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<BerserkerBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Berserker Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Berserker");
    }
}