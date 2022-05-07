using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class FrostCoreBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("FrostCore Boots");
        Tooltip.SetDefault("It's really cold!" +
                            "\n5 % increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.defense = 5;
        Item.value = Item.sellPrice(0, 0, 60);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.05f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(15)
        .AddTile(TileID.Anvils)
        .Register();
}