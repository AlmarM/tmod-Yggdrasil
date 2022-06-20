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
    public class HoneyGlazedStone : RunicItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Honey Glazed Stone");
            Tooltip.SetDefault("Drenches the owner in honey");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
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
            Item.shoot = ModContent.ProjectileType<HoneyStoneProjectile>();
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

            const int ExplosionProjectiles = 6;
            var Type = ProjectileID.Bee;


            for (int i = 0; i < ExplosionProjectiles; i++)
            {
                Vector2 Speed = Main.rand.NextVector2Unit();
                var Damage = Item.damage;
                var knockback = Item.knockBack;

                int proj = Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed, Type, Damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;

            }

            if (player.statLife < player.statLifeMax2)
            {
                int HealingValue = (runePlayer.InsanityValue * 2);

                player.statLife += HealingValue;
                player.HealEffect(HealingValue);

            }

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
            const int NumProjectiles = 7; // The number of projectiles.

            runePlayer.InsanityValue++;

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

        public override void HoldItem(Player player)
        {
            base.HoldItem(player);

            player.AddBuff(BuffID.Honey, 2);
        }

        protected override List<string> GetRunicEffectDescriptions()
        {
            List<string> descriptions = base.GetRunicEffectDescriptions();

            var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

            string focusLine = $"{focusColored}: ";
            focusLine += "Releases bees and heal the user. The more insanity, the more the heal!";

            descriptions.Add(focusLine);

            return descriptions;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.HoneyComb)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}
