using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners
{
    public class VolvaBanner : YggdrasilItem
    {
        public override void SetStaticDefaults()
        { 
            DisplayName.SetDefault("Volva Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Volva");

          CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 2, 0);
            Item.createTile = ModContent.TileType<VolvaBannerTile>();
            Item.placeStyle = 0;
        }
    }

}