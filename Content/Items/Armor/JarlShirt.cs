using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class JarlShirt : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        
        DisplayName.SetDefault("Jarl Shirt");
        Tooltip.SetDefault($"It's pretty warm");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.value = Item.sellPrice(0, 0, 30);
        Item.rare = ItemRarityID.Green;
        Item.defense = 5;
    }

    public override void UpdateEquip(Player player)
    {
        
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