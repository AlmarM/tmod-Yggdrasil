using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.RuneTablets
{
    public class ShinyTablet : RunicItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shiny Tablet");
            Tooltip.SetDefault("Generates light");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.crit = 1;
            Item.value = Item.sellPrice(0, 0, 18);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ShinyTabletProjectile>();
            Item.shootSpeed = 10f;
            Item.noUseGraphic = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            RunemasterPlayer runemasterPlayer = player.GetRunePlayer();

            if (runemasterPlayer.FocusValue >= runemasterPlayer.FocusThreshold)
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

            RunemasterPlayer runemasterPlayer = player.GetRunePlayer();

            const int ExplosionProjectiles = 9;
            var Type = ModContent.ProjectileType<ShinyTabletProjectile>();

            for (int i = 0; i < ExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type, Damage, knockback, player.whoAmI);

                player.AddBuff(BuffID.Spelunker, 600);

            }

            // Removing insanity when using a focus power
            runemasterPlayer.FocusValue = 0;
            if (runemasterPlayer.InsanityValue >= runemasterPlayer.InsanityRemoverValue)
            {
                runemasterPlayer.InsanityValue -= runemasterPlayer.InsanityRemoverValue;
            }
            else
            {
                runemasterPlayer.InsanityValue = 0;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // THE ATTACK

            RunemasterPlayer runemasterPlayer = player.GetRunePlayer();
            const int NumProjectiles = 3; // The number of projectiles.

            runemasterPlayer.InsanityValue++;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 16);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 8);

                float SpeedMultiplier = runemasterPlayer.RunicProjectileSpeedMultiplyer;

                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback, player.whoAmI);

            }

            return false;
        }

        public override void HoldItem(Player player)
        {
            base.HoldItem(player);

            RunemasterPlayer runemasterPlayer = player.GetRunePlayer();
            var centerX = (int)runemasterPlayer.Player.Center.X / 16;
            var centerY = (int)runemasterPlayer.Player.Center.Y / 16;

            Lighting.AddLight(centerX, centerY, 0.4f, 0.4f, 0.1f);
        }

        protected override List<string> GetRunicEffectDescriptions()
        {
            List<string> descriptions = base.GetRunicEffectDescriptions();

            var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

            string focusLine = $"{focusColored}: ";
            focusLine += "Releases a small explosion of projectiles around you & Shows the location of treasure and ore";

            descriptions.Add(focusLine);

            return descriptions;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.GoldBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

            CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.PlatinumBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
        }

    }
}
