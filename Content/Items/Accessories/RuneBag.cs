using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RuneBag : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        DisplayName.SetDefault("Rune Bag");
        Tooltip.SetDefault($"Increases {insanityText} gauge by 2" +
                           $"\nIncreases {runicText} damage by 1");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 25);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<RunePlayer>().InsanityThreshold += 2;
        player.GetDamage<RunicDamageClass>().Flat += 1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddIngredient<RunicSlab>()
        .AddTile(TileID.WorkBenches)
        .Register();
}