using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class SnowPlate : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Snow Plate");
        Tooltip.SetDefault($"It's cold");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.defense = 3;
        Item.value = Item.sellPrice(0, 0, 5);
    }

    public override void UpdateEquip(Player player)
    {
        
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SnowBlock, 40)
        .Register();
}