using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    public class HelsNail : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");

            DisplayName.SetDefault("Hel's Nail");
            Tooltip.SetDefault($"All {runicText} weapons now inflict poison for 5 sec" +
                               $"\n{runicPower} debuff time increases to 8 sec");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.SetEffect<HelsNail>();
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<BloodDrops>(10)
            .AddIngredient(ItemID.Stinger, 5)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}