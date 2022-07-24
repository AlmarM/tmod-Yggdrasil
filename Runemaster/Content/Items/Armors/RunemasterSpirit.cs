using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

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
        var runemasterPlayer = player.GetModPlayer<RunemasterPlayer>();
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string focusText2 = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        player.setBonus = $"10% increased {runicText} damage and critical strike chance" +
                          $"\nIncreases {insanityText} removed by {focusText} power by 6" +
                          $"\n{focusText2} power can be used faster" +
                          $"\nIncreases {insanityText} gauge by 20" +
                          $"\nGreatly increases {runicText} weapons range" +
                          $"\nReduces damage taken by 10%" +
                          $"\nGreatly Regenerates life";

        player.endurance += 0.1f;
        player.lifeRegen += 10;
        player.GetDamage<RunicDamageClass>() += 0.10f;
        player.GetCritChance<RunicDamageClass>() += 10;
        runemasterPlayer.InsanityThreshold += 20;
        runemasterPlayer.InsanityRemoverValue += 6;
        runemasterPlayer.RunicProjectileSpeedMultiplier += 5f;
        runemasterPlayer.FocusThreshold -= 4;
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