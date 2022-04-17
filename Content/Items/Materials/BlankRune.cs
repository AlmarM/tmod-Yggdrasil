using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class BlankRune : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blank Rune");
        Tooltip.SetDefault("A rune with no power.\n" +
                           "Used to craft powerful runes");
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.rare = ItemRarityID.White;
        Item.maxStack = 999;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10)
        .Register();
}