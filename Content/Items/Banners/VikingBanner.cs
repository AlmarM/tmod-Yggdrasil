using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class VikingBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<VikingBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Viking Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Vikings");
    }
}