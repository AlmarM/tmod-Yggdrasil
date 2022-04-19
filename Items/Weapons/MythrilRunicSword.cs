using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class MythrilRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mythril Runic Sword");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 23;
        Item.autoReuse = false;
        Item.damage = 45;
        Item.crit = 4;
        Item.knockBack = 6;
		Item.value = Item.buyPrice(0, 2, 53, 0);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.MythrilBar, 8)
		.AddIngredient(ItemID.CopperBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
		
		CreateRecipe()
		.AddIngredient(ItemID.MythrilBar, 8)
		.AddIngredient(ItemID.TinBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
		
	}
		

}