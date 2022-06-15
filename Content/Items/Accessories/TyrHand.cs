using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    public class TyrHand : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

            DisplayName.SetDefault("Tyr's Hand");
            Tooltip.SetDefault($"10% increase {runicText} attack speed" +
                               $"\n5% increase {runicText} damage");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<RunicDamageClass>() += 0.05f;
            player.SetEffect<TyrHand>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FeralClaws)
                .AddIngredient(ItemID.ViciousPowder, 5)
                .AddIngredient<BloodDrops>(5)
                .AddTile<DvergrForgeTile>()
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.FeralClaws)
                .AddIngredient(ItemID.VilePowder, 5)
                .AddIngredient<BloodDrops>(5)
                .AddTile<DvergrForgeTile>()
                .Register();
        }
    }
}