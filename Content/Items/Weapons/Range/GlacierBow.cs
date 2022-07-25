using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.Ammo;
using Yggdrasil.Frostcore.Content.Items.Weapons;

namespace Yggdrasil.Content.Items.Weapons.Range
{
    public class GlacierBow : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glacier Bow");
            Tooltip.SetDefault("That's a cold one" +
                               "\nWooden Arrows turn into FrostCore Arrows" +
							   "\nFire two arrows for the cost of one");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.useAmmo = AmmoID.Arrow;
			Item.knockBack = 4;
			Item.useTurn = false;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shootSpeed = 8f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ModContent.ProjectileType<FrostCoreArrowProjectile>();
			}
			Projectile.NewProjectile(source, position.X, position.Y-5, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y+5, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			return false;

		}

		public override void AddRecipes() => CreateRecipe()
            .AddIngredient<FrostcoreBow>()
			.AddIngredient<GlacierShards>(10)
			.AddTile(TileID.MythrilAnvil)
			.Register();
    }
}
