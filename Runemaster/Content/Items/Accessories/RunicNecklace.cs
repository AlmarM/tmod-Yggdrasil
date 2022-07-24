using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

[AutoloadEquip(EquipType.Neck)]
public class RunicNecklace : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        DisplayName.SetDefault("Runic Necklace");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\n5% increased {runicText} critical strike chance" +
                           "\nIncreases defense by 3" +
                           $"\nIncreases {insanityText} gauge by 8" +
                           "\nGenerates Light");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statDefense += 3;
        player.GetDamage<RunicDamageClass>() += 0.1f;
        player.GetCritChance<RunicDamageClass>() += 5;
        player.GetModPlayer<RunemasterPlayer>().InsanityThreshold += 8;

        Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .5f, .8f, .8f);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BerserkerRing>()
        .AddIngredient(ItemID.Bell)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}