using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Yggdrasil.Content.Items.Materials;
using Microsoft.Xna.Framework;

namespace Yggdrasil.Content.Items.Weapons.FrostCore
{
    public class FrostCoreTome : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frostcore Tome");
            Tooltip.SetDefault("It's really cold!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 1, 75);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.BallofFrost;
            Item.shootSpeed = 10f;
            Item.mana = 10;


        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.Book, 1)
            .AddIngredient<FrostCoreBar>(8)
            .Register();
    }
}
