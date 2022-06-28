using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class TrueValhallaSabaton : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("True Valhalla Sabaton");
        Tooltip.SetDefault($"30% increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.defense = 25;
        Item.value = Item.sellPrice(0, 6);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.3f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SquireAltPants) //Valhalla Greaves
        .AddIngredient<TrueHeroFragment>()
        .AddIngredient<SunPebble>()
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}