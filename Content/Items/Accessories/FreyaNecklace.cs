using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    public class FreyaNecklace : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            //string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");

            DisplayName.SetDefault("Freya's Necklace");
            Tooltip.SetDefault($"Hitting an enemy with a {runicText} weapon has a chance to generate a heart");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.SetEffect<FreyaNecklace>();

            //Adding a variable here because I want to be able to buff this with other things
            //player.GetModPlayer<RunePlayer>().FreyaNecklaceChance += 0.5f;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.Prismite)
            .AddIngredient<BloodDrops>(5)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}