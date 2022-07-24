using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class SvartalslimeBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<SvartalslimeBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Svartalslime Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Svartalslime");
    }
}