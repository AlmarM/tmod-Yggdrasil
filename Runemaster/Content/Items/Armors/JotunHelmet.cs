using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Head)]
public class JotunHelmet : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Jotun Helmet");
        Tooltip.SetDefault($"Increases {runicText} damage by 6");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.defense = 13;
        Item.value = Item.sellPrice(0, 4);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<JotunPlate>() &&
               legs.type == ModContent.ItemType<JotunGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {
        var runemasterPlayer = player.GetModPlayer<RunemasterPlayer>();
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");

        player.setBonus = $"Increases {insanityText} removed by {focusText} power by 1" +
                          $"\nIncreases {insanityText} gauge by 8" +
                          "\nReduces damage taken by 5%" +
                          "\nIncrease max life by 20";

        player.endurance += 0.05f;
        player.statLifeMax2 += 20;

        runemasterPlayer.InsanityThreshold += 8;
        runemasterPlayer.InsanityRemoverValue += 1;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 6;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}