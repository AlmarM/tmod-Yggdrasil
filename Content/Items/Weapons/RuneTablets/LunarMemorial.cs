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
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.RuneTablets
{
    public class LunarMemorial : RunicItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunar Memorial");
            Tooltip.SetDefault("");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.crit = 5;
            Item.value = Item.sellPrice(0, 5);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<LunarMemorialNormalProjectile>();
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

            const int NebulaExplosionProjectiles = 3;
            const int SolarExplosionProjectiles = 10;
            const int VortexxplosionProjectiles = 6;
            var Type1 = ModContent.ProjectileType<LunarMemorialNebulaProjectile>();
            var Type2 = ModContent.ProjectileType<LunarMemorialSolarProjectile>();
            var Type3 = ModContent.ProjectileType<LunarMemorialVortexProjectile>();

            //Nebula
            for (int i = 0; i < NebulaExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type1, (Damage * 2), knockback, player.whoAmI);
                
            }

            //Solar
            for (int i = 0; i < SolarExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type2, (Damage * 3), knockback, player.whoAmI);

            }

            //Vortex
            for (int i = 0; i < VortexxplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 12, Type3, Damage, knockback, player.whoAmI);

            }

            //Stardust
            //

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
            const int NumProjectiles = 12; // The number of projectiles.

            runePlayer.InsanityValue++;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
                float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 28);
                Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 14);

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
            focusLine += "Releases projectiles from every facet of the lunar power";

            descriptions.Add(focusLine);

            return descriptions;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.FragmentNebula, 5)
            .AddIngredient(ItemID.FragmentVortex, 5)
            .AddIngredient(ItemID.FragmentStardust, 5)
            .AddIngredient(ItemID.FragmentSolar, 5)
            .AddTile(TileID.LunarCraftingStation)
            .Register();        
    }
}
