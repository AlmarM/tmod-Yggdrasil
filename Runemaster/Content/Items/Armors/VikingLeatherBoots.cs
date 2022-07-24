using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Legs)]
public class VikingLeatherBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Leather Boots");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.defense = 2;
        Item.value = Item.sellPrice(0, 0, 5);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddTile(TileID.WorkBenches)
        .Register();
}