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
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Runic;
using Yggdrasil.Utils;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Weapons.RuneTablets
{
    public class SpikyBlock : RunicItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Block");
            Tooltip.SetDefault("Watch your fingers");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.crit = 2;
            Item.value = Item.sellPrice(0, 0, 55);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SpikyBlockProjectile>();
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

            const int ExplosionProjectiles = 10;
            var Type = ProjectileID.SpikyBall;

            for (int i = 0; i < ExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type, Damage, knockback, player.whoAmI);      
            }

            player.AddBuff(ModContent.BuffType<SpikyBuff>(), 300);

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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // THE ATTACK

            RunePlayer runePlayer = player.GetRunePlayer();
            const int NumProjectiles = 6; // The number of projectiles.

            runePlayer.InsanityValue++;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 16);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 8);

                float SpeedMultiplier = runePlayer.RunicProjectileSpeedMultiplyer;

                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback, player.whoAmI);

            }

            return false;
        }

        protected override List<string> GetRunicEffectDescriptions()
        {
            List<string> descriptions = base.GetRunicEffectDescriptions();

            var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

            string focusLine = $"{focusColored}: ";
            focusLine += "Releases a bunch of spiky balls and applies Spiky buff";

            descriptions.Add(focusLine);

            return descriptions;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.SpikyBall, 50)
            .AddTile<DvergrForgeTile>()
            .Register();

        

    }
}
