using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class FrostcorePlate : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Plate");
        Tooltip.SetDefault("It's really cold!" +
                            "\nAttackers also take some damage");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.defense = 6;
        Item.value = Item.sellPrice(0, 0, 60);
    }

    public override void UpdateEquip(Player player)
    {
        player.thorns += .05f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreBar>(20)
        .AddTile(TileID.Anvils)
        .Register();
}