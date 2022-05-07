using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Weapons.FrostCore
{
    public class FrostCoreBow : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("FrostCore Bow");
            Tooltip.SetDefault("It's really cold!"+
                               "\nWooden Arrows turn into FrostCore Arrows");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.useAmmo = AmmoID.Arrow;
			Item.knockBack = 4;
			Item.useTurn = false;
			Item.value = Item.sellPrice(0, 0, 23);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shootSpeed = 4.25f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ModContent.ProjectileType<FrostCoreArrowProjectile>();
			}
			Projectile.NewProjectile(null, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			return false;

		}


		public override void AddRecipes() => CreateRecipe()
            .AddIngredient<FrostCoreBar>(8)
            .Register();
    }
}
