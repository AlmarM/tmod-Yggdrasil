using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunicNecklace : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Runic Necklace");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\n5% increased {runicText} critical strike chance" +
                           "\nIncreases defense by 3" +
                           "\nIncreases insanity gauge by 8" +
                           $"\nGenerates Light");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.1f;
        player.GetCritChance<RunicDamageClass>() += 5;
        player.statDefense += 3;
        player.GetModPlayer<RunePlayer>().InsanityThreshold += 8;

        Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .5f, .8f, .8f);

    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BerserkerRing>()
        .AddIngredient(ItemID.Bell)
        .AddTile<DvergrForgeTile>()
        .Register();
}