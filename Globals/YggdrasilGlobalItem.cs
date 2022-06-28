using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.RuneTablets;

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

    public override void OpenVanillaBag(string context, Player player, int arg)
    {
        if (context == "bossBag" && arg == ItemID.PlanteraBossBag)
        {
            player.QuickSpawnItem(null, ModContent.ItemType<SturdyLeaf>(), 30);
        }

        if (context == "bossBag" && arg == ItemID.GolemBossBag)
        {
            player.QuickSpawnItem(null, ModContent.ItemType<SunPebble>(), 3);

            if (Main.rand.NextBool(4))
                player.QuickSpawnItem(null, ModContent.ItemType<SunTablet>(), 1);
            
        }

        if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
        {
            if (Main.rand.NextBool(4))
                player.QuickSpawnItem(null, ModContent.ItemType<Ragnarok>(), 1);
        }
    }
}