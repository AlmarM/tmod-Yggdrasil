using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class GlacierGreaves : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Glacier Greaves");
        Tooltip.SetDefault($"10% increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.defense = 11;
        Item.value = Item.sellPrice(0, 1);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.1f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(5)
        .AddIngredient<GlacierShards>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}