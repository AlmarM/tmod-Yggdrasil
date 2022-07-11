using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;

namespace Yggdrasil.Runes;

public abstract class Rune : YggdrasilItem
{
    protected abstract string ItemName { get; }

    protected abstract RuneTier Tier { get; }

    protected virtual int RunePower => 1;

    protected virtual int Rarity => ItemRarityID.White;

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault(GetFinalItemName());
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = 1;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe().AddIngredient<BlankRune>();

        SetupRecipe(recipe);

        recipe.AddTile<DvergrPowerForgeTile>().Register();
    }

    protected virtual void SetupRecipe(Recipe recipe)
    {
    }

    protected virtual string GetFinalItemName()
    {
        string prefix = Tier.GetItemPrefix();

        if (!string.IsNullOrEmpty(prefix))
        {
            prefix += " ";
        }

        return $"{prefix}{ItemName} Rune";
    }
}