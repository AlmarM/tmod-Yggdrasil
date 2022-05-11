using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Configs;
using Yggdrasil.Utils;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.Content.Items.Accessories
{
    public class TyrHand : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");

            DisplayName.SetDefault("Tyr's Hand");
            Tooltip.SetDefault($"10% increase {runicText} attack speed" +
                               $"\nEnables auto swing for {runicText} weapons" +
                               $"\n{runicPower} 5% increase {runicText} damage");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.SetEffect<TyrHand>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FeralClaws)
                .AddIngredient(ItemID.ViciousPowder, 5)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.FeralClaws)
                .AddIngredient(ItemID.VilePowder, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}