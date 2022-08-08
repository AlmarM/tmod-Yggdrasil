using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Runemaster.Content.Items.Accessories;
using Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

namespace Yggdrasil.Globals;

public class YggdrasilGlobalItem : GlobalItem
{
    public override void AddRecipes()
    {
        Recipe recipe = Recipe.Create(ItemID.AvengerEmblem);
        recipe.AddIngredient<RunemasterEmblem>();
        recipe.AddIngredient(ItemID.SoulofMight, 5);
        recipe.AddIngredient(ItemID.SoulofSight, 5);
        recipe.AddIngredient(ItemID.SoulofFright, 5);
        recipe.AddTile(TileID.TinkerersWorkbench);
        recipe.Register();
    }

    public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
    {
        switch (item.type)
        {
            case ItemID.PlanteraBossBag:
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SturdyLeaf>(), 1, 25, 35));
                break;

            case ItemID.GolemBossBag:
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SunPebble>(), 1, 2, 4));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SunTablet>(), 4));
                break;

            case ItemID.MoonLordBossBag:
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Ragnarok>(), 4));
                break;
        }
    }
}