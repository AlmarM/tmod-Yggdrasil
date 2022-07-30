using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Frostcore.Content.Items.Ores;

namespace Yggdrasil.Frostcore.Content.Items.Armors;

[AutoloadEquip(EquipType.Legs)]
public class FrostcoreBoots : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Boots");
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
        .AddIngredient<FrostcoreBar>(15)
        .AddTile(TileID.Anvils)
        .Register();
}