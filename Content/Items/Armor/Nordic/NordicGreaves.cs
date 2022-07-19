using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor.Nordic;

[AutoloadEquip(EquipType.Legs)]
public class NordicGreaves : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nordic Greaves");
        Tooltip.SetDefault("Increases movement speed by 20%");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.defense = 22;
        Item.value = Item.sellPrice(0, 5);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.2f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBoots>()
        .AddIngredient<ColdIronBar>(5)
        .AddTile(TileID.MythrilAnvil)
        .Register();
}