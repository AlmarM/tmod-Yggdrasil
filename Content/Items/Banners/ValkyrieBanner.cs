using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners;

public class ValkyrieBanner : YggdrasilBannerItem
{
    protected override int BannerTileType => ModContent.TileType<ValkyrieBannerTile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Valkyrie Banner");
        Tooltip.SetDefault("Nearby players get a bonus against: Valkyrie");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.sellPrice(gold: 1);
    }
}