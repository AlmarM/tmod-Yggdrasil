using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.RuneTablets
{
    public class SunTablet : RunicItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun Tablet");
            Tooltip.SetDefault("That one's heavy");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.crit = 4;
            Item.value = Item.sellPrice(0, 15);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SunTabletProjectile>();
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
            // THE FOCUS POWER

            RunePlayer runePlayer = player.GetRunePlayer();

            const int ExplosionProjectiles = 8;
            var Type = ProjectileID.BoulderStaffOfEarth;

            for (int i = 0; i < ExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                int proj = Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type, Damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
            }

            player.AddBuff(ModContent.BuffType<TheSunBuff>(), 300);

            // Removing insanity when using a focus power
            runePlayer.FocusValue = 0;
            if (runePlayer.InsanityValue >= runePlayer.InsanityRemoverValue)
            {
                runePlayer.InsanityValue -= runePlayer.InsanityRemoverValue;
            }
            else
            {
                runePlayer.InsanityValue = 0;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
            Vector2 velocity, int type, int damage, float knockback)
        {
            // THE ATTACK

            RunePlayer runePlayer = player.GetRunePlayer();
            const int NumProjectiles = 10; // The number of projectiles.
            var Type2 = ProjectileID.BoulderStaffOfEarth;
            runePlayer.InsanityValue++;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 28);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 14);

                float SpeedMultiplier = runePlayer.RunicProjectileSpeedMultiplyer;

                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback,
                    player.whoAmI);

                if (Main.rand.Next(100) < 2)
                {
                    Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * 10, Type2, damage, knockback,
                    player.whoAmI);
                }
            }

            return false;
        }

        protected override List<string> GetRunicEffectDescriptions()
        {
            List<string> descriptions = base.GetRunicEffectDescriptions();

            var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

            string focusLine = $"{focusColored}: ";
            focusLine += "Releases an explosion of boulders and applies The Sun buff";

            descriptions.Add(focusLine);

            return descriptions;
        }

        //Dropped by Golem
    }
}