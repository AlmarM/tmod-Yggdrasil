using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Legs)]
public class JotunGreaves : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jotun Greaves");
        Tooltip.SetDefault("15% increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.defense = 12;
        Item.value = Item.sellPrice(0, 4);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.15f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}