using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class GrassRunicBlade : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Grass Runic Blade");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 4;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(0, 0, 55, 0);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
		if (Main.rand.NextFloat() < .25f)
		{
				target.AddBuff(BuffID.Poisoned, 300);
		}
	}

    public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.Stinger, 15)
		.AddIngredient(ItemID.JungleSpores, 15)
		.AddTile(TileID.Anvils)
        .Register();
		

}