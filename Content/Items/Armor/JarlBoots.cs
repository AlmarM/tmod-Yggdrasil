using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.DamageClasses;
using Yggdrasil.Items;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class JarlBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Jarl Boots");
        Tooltip.SetDefault($"2% increased {runicText} damage" +
                           "\n8% increase movement speed");
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Green;
        Item.defense = 4;
        Item.value = Item.sellPrice(0, 30);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.08f;
        player.GetDamage<RunicDamageClass>() += 0.02f;
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