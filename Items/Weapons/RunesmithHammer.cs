using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class RunesmithHammer : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runesmith Hammer");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.autoReuse = false;
        Item.damage = 9;
        Item.crit = 4;
        Item.knockBack = 10;
		Item.hammer = 45;
		Item.value = Item.buyPrice(0, 0, 5, 40);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 15)
		.AddIngredient(ItemID.IronBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
		
		CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 15)
		.AddIngredient(ItemID.LeadBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
	}
		

}