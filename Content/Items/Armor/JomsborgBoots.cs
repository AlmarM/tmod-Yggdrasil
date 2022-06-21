using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class JomsborgBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jomsborg Boots");
        Tooltip.SetDefault($"15% increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;
        Item.defense = 15;
        Item.value = Item.sellPrice(0, 4, 80);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.15f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SturdyLeaf>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}