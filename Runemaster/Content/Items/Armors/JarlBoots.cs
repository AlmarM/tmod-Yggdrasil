using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Legs)]
public class JarlBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jarl Boots");
        Tooltip.SetDefault("5% increase movement speed");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Green;
        Item.defense = 4;
        Item.value = Item.sellPrice(0, 0, 30);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.05f;
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