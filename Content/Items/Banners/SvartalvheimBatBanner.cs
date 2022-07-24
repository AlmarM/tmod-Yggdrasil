using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class SvartalvheimBatBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<SvartalvheimBatBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        DisplayName.SetDefault("Svartalvheim Bat Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Svartalvheim Bat");
    }
}