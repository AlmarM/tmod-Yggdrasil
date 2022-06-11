using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.RuneTablets
{
    public class HellishTablet : RunicItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellish Tablet");
            Tooltip.SetDefault("That one's pretty hot");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.crit = 3;
            Item.value = Item.sellPrice(0, 1);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<HellishTabletProjectile>();
            Item.shootSpeed = 10f;
            Item.noUseGraphic = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            RunePlayer runePlayer = player.GetRunePlayer();

            if (runePlayer.FocusValue >= runePlayer.FocusThreshold)
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

            // THE RELEASE

            RunePlayer runePlayer = player.GetRunePlayer();

            const int ExplosionProjectiles = 10;
            const int ExplosionProjectiles2 = 5;
            var Type = ProjectileID.BallofFire;
            var Type2 = ModContent.ProjectileType<HellishTabletProjectile>();
            var Damage = Item.damage;
            var knockback = Item.knockBack;

            for (int i = 0; i < ExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type, Damage, knockback, player.whoAmI);

            }
            for (int i = 0; i < ExplosionProjectiles2; i++)
            {
                Vector2 Speed2 = Main.rand.NextVector2Unit();

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed2 * 10, Type2, Damage, knockback, player.whoAmI);

            }

            runePlayer.FocusValue = 0;
            if (runePlayer.InsanityValue >= 10)
            {
                runePlayer.InsanityValue -= 10;
            }
            else
            {
                runePlayer.InsanityValue = 0;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // THE BREATH

            RunePlayer runePlayer = player.GetRunePlayer();
            const int NumProjectiles = 8; // The number of projectiles.

            runePlayer.InsanityValue++;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 16);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 8);

                //Vector2 Mouth = new Vector2(player.Center.X, (player.Center.Y - 5)); Doesn't scale if player is mounted

                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * 10, type, damage, knockback, player.whoAmI);

            }

            if (Main.rand.NextFloat() < .1f)
            {
                // @todo clean up in the future
                var x = player.Center.X;
                var y = player.Center.Y;

                var direction = Main.MouseWorld - player.Center;
                direction.Normalize();

                var speed = 6f;
                float speedX = direction.X * speed;
                float speedY = direction.Y * speed;
                int projectileType = ProjectileID.BallofFire;

                Projectile.NewProjectile(null, x, y, speedX, speedY, projectileType, damage, 0,
                    player.whoAmI);
            }

            return false;
        }

        protected override List<string> GetRunicEffectDescriptions()
        {
            List<string> descriptions = base.GetRunicEffectDescriptions();

            var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

            string focusLine = $"{focusColored}: ";
            focusLine += "Releases an explosion of projectiles and fireballs";

            descriptions.Add(focusLine);

            return descriptions;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.Obsidian, 20)
            .AddIngredient(ItemID.HellstoneBar, 6)
            .AddTile<DvergrForgeTile>()
            .Register();        
    }
}
