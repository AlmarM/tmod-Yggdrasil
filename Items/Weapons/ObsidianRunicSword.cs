using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class ObsidianRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Obsidian Runic Sword");
		Tooltip.SetDefault("Hot to the touch");

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
        Item.damage = 35;
        Item.crit = 4;
        Item.knockBack = 6;
		Item.value = Item.buyPrice(copper: 20);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
		if (Main.rand.NextFloat() < .5f)
		{
			target.AddBuff(BuffID.OnFire, 120);
		}
	}
	
	public override void MeleeEffects(Player player, Rectangle hitbox) 
	{
			int dustType = 127;
			int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dustType);
			Dust dust = Main.dust[dustIndex];
			dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
	}

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HellstoneBar, 20)
		.AddIngredient(ItemID.Obsidian, 20)
		.AddTile(TileID.Anvils)
        .Register();
}