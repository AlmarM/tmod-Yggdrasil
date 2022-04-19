using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class HallowedRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hallowed Runic Sword");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = false;
        Item.damage = 66;
        Item.crit = 5;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(0, 4, 60, 0);
        Item.rare = ItemRarityID.Pink;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.HallowedBar, 10)
		.AddIngredient(ItemID.MythrilBar, 5)
		.AddTile(TileID.Anvils)
        .Register();
		
		CreateRecipe()
		.AddIngredient(ItemID.HallowedBar, 10)
		.AddIngredient(ItemID.OrichalcumBar, 5)
		.AddTile(TileID.Anvils)
        .Register();
		
	}
		

}