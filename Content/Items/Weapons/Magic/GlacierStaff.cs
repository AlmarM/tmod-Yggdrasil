using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.FrostCore;
using Yggdrasil.Content.Projectiles.Magic;

namespace Yggdrasil.Content.Items.Weapons.Magic
{
    public class GlacierStaff : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glacier Staff");
            Tooltip.SetDefault("That's a cold one" + "\nThrows 2 homings ice chunks that applies Frostburn");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 12;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<GlacierStaffProjectile>();
            Item.shootSpeed = 10f;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2; // The number of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 16);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 8);

                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * 10, type, damage, knockback,
                    player.whoAmI);
            }

            return false;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<FrostCoreTome>()
            .AddIngredient<GlacierShards>(10)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}
