using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Extensions;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class GlacierHelmet : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Glacier Helmet");
        Tooltip.SetDefault($"Increases {runicText} damage by 4");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.defense = 11;
        Item.value = Item.sellPrice(0, 1);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<GlacierPlate>() &&
               legs.type == ModContent.ItemType<GlacierGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {

        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");

        player.setBonus = $"Increases {insanityText} removed by {focusText} power by 1\nIncreases {insanityText} gauge by 5\nGetting hit will slow down the enemy";

        player.SetEffect<GlacierHelmet>();
        player.GetModPlayer<RunePlayer>().InsanityThreshold += 5;
        player.GetModPlayer<RunePlayer>().InsanityRemoverValue += 1;

    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 4;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(5)
        .AddIngredient<GlacierShards>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}