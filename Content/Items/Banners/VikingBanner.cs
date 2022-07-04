using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Banners;

namespace Yggdrasil.Content.Items.Banners
{
    public class VikingBanner : YggdrasilItem
    {
        public override void SetStaticDefaults()
        { 
            DisplayName.SetDefault("Viking Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Vikings");

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
            Item.createTile = ModContent.TileType<VikingBannerTile>();
            Item.placeStyle = 0;
        }
    }

}