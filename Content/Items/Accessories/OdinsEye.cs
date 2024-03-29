using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    public class OdinsEye : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Odin's Eye");
            Tooltip.SetDefault("Grants 10% to avoid a fatal blow and heal back to 20% life");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.SetEffect<OdinsEye>();
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<BloodDrops>(10)
            .AddIngredient(ItemID.SoulofSight, 10)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}