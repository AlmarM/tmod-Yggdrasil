using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    public class NidhoggTooth : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
            string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 10+");

            DisplayName.SetDefault("Nidhogg's Tooth");
            Tooltip.SetDefault($"{runicPower} 5% increased {runicText} critical strike chance" +
                               $"\nHitting an enemy with a {runicText} weapon slows the target by 25% for 3 sec");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 3);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RunePlayer>().SlowDebuffValue = .75f; //it means 25% slow
            player.GetCritChance<RunicDamageClass>() += 5;
            player.SetEffect<NidhoggTooth>();
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.SpiderFang, 5)
            .AddIngredient(ItemID.PixieDust, 10)
            .AddIngredient(ItemID.VialofVenom)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}