using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Frostcore.Content.Items.Ores;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Legs)]
public class GlacierGreaves : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Glacier Greaves");
        Tooltip.SetDefault("10% increase movement speed");

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
        .AddIngredient<FrostcoreBar>(5)
        .AddIngredient<GlacierShards>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}