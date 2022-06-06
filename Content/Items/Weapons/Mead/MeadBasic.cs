using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;

namespace Yggdrasil.Content.Items.Weapons.Mead
{
    public class MeadBasic : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Basic Mead");
            Tooltip.SetDefault("It's sweet");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 2;
            Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
            Item.mana = 0;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 1, 75);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<BreathProjectile>();
            Item.shootSpeed = 10f;
            Item.noUseGraphic = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            RunePlayer runePlayer = player.GetRunePlayer();

            if (runePlayer.FartValue >= runePlayer.FartThreshold)
            {
                return true;
            }

            return false;
        }

        public override bool? UseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                OnRightClick(player);

                return true;
            }

            return base.UseItem(player);
        }

        protected virtual void OnRightClick(Player player)
        {

            // THE FART

            RunePlayer runePlayer = player.GetRunePlayer();

            const int NumProjectiles2 = 10;
            var Type = ModContent.ProjectileType<BreathProjectile>();

            for (int i = 0; i < NumProjectiles2; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;
                
                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type, Damage, knockback, player.whoAmI);

            }

            runePlayer.FartValue = 0;
            if (runePlayer.PukeValue >= 10)
            {
                runePlayer.PukeValue -= 10;
            }
            else
            {
                runePlayer.PukeValue = 0;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // THE BREATH

            RunePlayer runePlayer = player.GetRunePlayer();
            const int NumProjectiles = 10; // The number of projectiles.

            runePlayer.PukeValue++;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 12);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 6);
                
                //Vector2 Mouth = new Vector2(player.Center.X, (player.Center.Y - 5)); Doesn't scale if player is mounted

                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * 10, type, damage, knockback, player.whoAmI);

            }

            return false;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.DirtBlock)
            .Register();
    }
}
