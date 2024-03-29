using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor.Runemaster;

[AutoloadEquip(EquipType.Legs)]
public class RunemasterSabaton : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runemaster Sabaton");
        Tooltip.SetDefault($"35% increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Red;
        Item.defense = 30;
        Item.value = Item.sellPrice(0, 10);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.35f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.LunarBar, 8)
        .AddIngredient<ColdIronBar>(3)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
}