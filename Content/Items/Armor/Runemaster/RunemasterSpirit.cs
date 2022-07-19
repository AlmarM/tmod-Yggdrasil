using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor.Runemaster;

[AutoloadEquip(EquipType.Head)]
public class RunemasterSpirit : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Runemaster Spirit");
        Tooltip.SetDefault($"Increases {runicText} damage by 15");
        ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }


    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Red;
        Item.defense = 20;
        Item.value = Item.sellPrice(0, 10);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<RunemasterCore>() &&
               legs.type == ModContent.ItemType<RunemasterSabaton>();
    }

    public override void UpdateArmorSet(Player player)
    {

        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string focusText2 = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        player.setBonus = $"10% increased {runicText} damage and critical strike chance\nIncreases {insanityText} removed by {focusText} power by 6\n{focusText2} power can be used faster\nIncreases {insanityText} gauge by 20\nGreatly increases {runicText} weapons range\nReduces damage taken by 10%\nGreatly Regenerates life\n";

        player.endurance += 0.1f;
        player.lifeRegen += 10;
        player.GetModPlayer<RunePlayer>().InsanityThreshold += 20;
        player.GetModPlayer<RunePlayer>().InsanityRemoverValue += 6;
        player.GetModPlayer<RunePlayer>().RunicProjectileSpeedMultiplyer += 5f;
        player.GetModPlayer<RunePlayer>().FocusThreshold -= 4;
        player.GetDamage<RunicDamageClass>() += 0.10f;
        player.GetCritChance<RunicDamageClass>() += 10;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 12;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.LunarBar, 10)
        .AddIngredient<ColdIronBar>(3)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
}