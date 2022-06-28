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

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class TrueValhallaHaume : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("True Valhalla Haume");
        Tooltip.SetDefault($"Increases {runicText} damage by 12");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.defense = 25;
        Item.value = Item.sellPrice(0, 6);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<TrueValhallaSuit>() &&
               legs.type == ModContent.ItemType<TrueValhallaSabaton>();
    }

    public override void UpdateArmorSet(Player player)
    {

        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        player.setBonus = $"Increases {insanityText} removed by {focusText} power by 4\nIncreases {insanityText} gauge by 15\nIncreases {runicText} weapons range\nReduces damage taken by 8%\nRegenerates life\nGrants immunity to knockback";

        player.endurance += 0.08f;
        player.lifeRegen += 8;
        player.GetModPlayer<RunePlayer>().InsanityThreshold += 15;
        player.GetModPlayer<RunePlayer>().InsanityRemoverValue += 3;
        player.noKnockback = true;
        player.GetModPlayer<RunePlayer>().RunicProjectileSpeedMultiplyer += 2f;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 12;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SquireAltHead) //Valhalla Helm
        .AddIngredient<TrueHeroFragment>()
        .AddIngredient<SunPebble>()
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}