using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class ArmRing : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        DisplayName.SetDefault("Armring");
        Tooltip.SetDefault($"Increases {runicText} damage by 1" +
                           "\nIncreases defense by 1" +
                           $"\nIncreases {insanityText} gauge by 5");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 10);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>().Flat += 1;
        player.statDefense += 1;
        player.GetModPlayer<RunemasterPlayer>().InsanityThreshold += 5;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<WoodArmRing>()
        .AddIngredient<NordicWood>(10)
        .AddRecipeGroup(RecipeGroupID.IronBar, 2)
        .AddTile(TileID.Anvils)
        .Register();
}