using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]

    public class RunemasterNecklace : YggdrasilItem
    {

        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
            string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

            DisplayName.SetDefault("Runemaster Necklace");
            Tooltip.SetDefault($"15% increased {runicText} damage" +
                               $"\n5% increased {runicText} critical strike chance" +
                               "\nIncreases defense by 5" +
                               $"\nIncreases {insanityText} gauge by 10" +
                               $"\n{focusText} power can be used faster" +
                               $"\nGenerates Light");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 7);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<RunicDamageClass>() += 0.15f;
            player.GetCritChance<RunicDamageClass>() += 5;
            player.statDefense += 5;
            player.GetModPlayer<RunemasterPlayer>().InsanityThreshold += 10;
            player.GetModPlayer<RunemasterPlayer>().FocusThreshold -= 2;

            Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .8f, .7f, .3f);

        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<RunicNecklace>()
            .AddIngredient<SunPebble>()
            .AddIngredient<TrueHeroFragment>()
            .AddTile<DvergrPowerForgeTile>()
            .Register();
    }
}