using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class VikingLeatherShirt : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Leather Shirt");
        //Tooltip.SetDefault("");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.value = Item.sellPrice(0, 0, 5);
        Item.rare = ItemRarityID.White;
        Item.defense = 2;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddTile(TileID.WorkBenches)
        .Register();
}