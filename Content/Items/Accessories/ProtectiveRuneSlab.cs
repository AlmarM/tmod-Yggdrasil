using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class ProtectiveRuneSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {

        DisplayName.SetDefault("Protective Runic Slab");
        Tooltip.SetDefault($"Displays focus and insanity" +
                           $"\nIncreases defense by 5");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 7);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statDefense += 5;
        player.SetEffect<RunicSlab>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RunicSlab>()
        .AddIngredient(ItemID.TurtleShell)
        .AddTile<DvergrForgeTile>()
        .Register();
}