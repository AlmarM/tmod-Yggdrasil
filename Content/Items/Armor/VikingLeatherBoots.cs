using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class VikingLeatherBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Leather Boots");
        Tooltip.SetDefault("5% increase movement speed");
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.defense = 2;
        Item.value = Item.sellPrice(0, 0, 5);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.05f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddTile(TileID.WorkBenches)
        .Register();
}