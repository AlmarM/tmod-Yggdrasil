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
    public class ValkyrieLightStaff : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Valkyrie Light Staff");
            Tooltip.SetDefault("Throws many enchanted spearhead");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 15;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 6);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ValkyrieLightStaffProjectile>();
            Item.shootSpeed = 10f;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 direction = Vector2.Normalize(Main.MouseWorld - player.Center) * 10f;

            int NumProjectiles = Main.rand.Next(3, 5);
            for (int i = 0; i < NumProjectiles; ++i)
            {
                float SpeedMult = Main.rand.Next(100, 150) * 0.01f;
                Projectile.NewProjectile(source, Main.LocalPlayer.Center, direction * SpeedMult, type, damage, knockback,
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
