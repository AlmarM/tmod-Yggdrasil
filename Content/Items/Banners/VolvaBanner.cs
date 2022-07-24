using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class VolvaBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<VolvaBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Volva Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Volva");
    }
}