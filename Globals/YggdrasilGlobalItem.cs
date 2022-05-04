using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;

namespace Yggdrasil.Globals;

public class YggdrasilGlobalItem : GlobalItem
{
    public override void AddRecipes()
    {
        Recipe recipe = Mod.CreateRecipe(ItemID.AvengerEmblem);
        recipe.AddIngredient<RunemasterEmblem>();
        recipe.AddIngredient(ItemID.SoulofMight, 5);
        recipe.AddIngredient(ItemID.SoulofSight, 5);
        recipe.AddIngredient(ItemID.SoulofFright, 5);
        recipe.Register();
    }
}