using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class DemoniteRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");
        string runicPowerFourText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");

        DisplayName.SetDefault("Demonite Runic Axe");
        Tooltip.SetDefault($"{runicPowerTwoText}: 5% increased {runicText} critical strike chance" +
                           $"\n{runicPowerFourText} Spawn an axe clone on critical strike");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 6;
        Item.knockBack = 6;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 27, 0);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.DemoniteBar, 12)
        .AddTile(TileID.Anvils)
        .Register();

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            crit += 5;
        }
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 4 && crit)
        {
            if (crit)
            {
                // @todo clean up in the future
                var radius = 200f;
                var theta = Main.rand.NextFloat(0, MathF.PI * 2f);
                var x = target.Center.X + MathF.Cos(theta) * radius;
                var y = target.Center.Y + MathF.Sin(theta) * radius;

                var direction = target.Center - new Vector2(x, y);
                direction.Normalize();

                var speed = 6f;
                float speedX = direction.X * speed;
                float speedY = direction.Y * speed;
                int projectileType = ModContent.ProjectileType<DemoniteRunicAxeProjectile>();
                int projectileDamage = Item.damage;

                Projectile.NewProjectile(null, x, y, speedX, speedY, projectileType, projectileDamage, 0,
                    player.whoAmI);
            }
        }
    }
}