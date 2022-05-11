using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Configs;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.Content.Items.Accessories
{
    public class OdinsEye : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 10+");

            DisplayName.SetDefault("Odin's Eye");
            Tooltip.SetDefault("Grants 10% to avoid a fatal blow and heal back to 20% life" +
                               $"\n{runicPower} Heal back to 50% life instead");
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
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}