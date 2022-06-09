using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class JarlHelmet : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Jarl Helmet");
        Tooltip.SetDefault($"4% increased {runicText} damage");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Green;
        Item.defense = 4;
        Item.value = Item.sellPrice(0, 0, 30);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<JarlShirt>() &&
               legs.type == ModContent.ItemType<JarlBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {

        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        player.setBonus = $"4% increased {runicText} damage" +
                          "\nSlowly regenerate life";

        player.GetDamage<RunicDamageClass>() += 0.04f;

        var runePlayer = player.GetModPlayer<RunePlayer>();
        runePlayer.RunePower += 1;

        player.lifeRegen += 5;
        
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>() += 0.04f;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<Linnen>(10)
            .AddIngredient(ItemID.GoldBar, 10)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient<Linnen>(10)
            .AddIngredient(ItemID.PlatinumBar, 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}