using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class OdinsRavenBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<OdinsRavenBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        DisplayName.SetDefault("Odin's Raven Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Odin's Raven");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
}