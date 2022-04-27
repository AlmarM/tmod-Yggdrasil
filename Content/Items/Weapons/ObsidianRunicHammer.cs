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

public class ObsidianRunicHammer : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        //string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");

        DisplayName.SetDefault("Obsidian Runic Hammer");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: Increase Size & 50% chance to inflict fire damage for 3 sec" +
            $"\n{runicPowerTwoText}: Generate fireballs on hit based on {runicPowerText}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 30;
        Item.crit = 0;
        Item.knockBack = 10;
        Item.hammer = 70;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    public override void HoldItem(Player player)
    {
        Item.scale = 1f;

        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            Item.scale += 0.5f;
        }
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 4)
        {
            int projectileCount = runePlayer.RunePower;
            if (projectileCount >= 6)
                projectileCount = 6;

            const float projectileSpeed = 6f;
            const float radius = 25f;

            float delta = MathF.PI * 2 / projectileCount;

            for (var i = 0; i < projectileCount; i++)
            {
                float theta = delta * i;
                var position = target.Center + Vector2.One.RotatedBy(theta) * radius;

                Vector2 direction = position - target.Center;
                direction = Vector2.Normalize(direction);
                direction = Vector2.Multiply(direction, projectileSpeed);

                Projectile.NewProjectile(null, position, direction, ModContent.ProjectileType<FireProjectile>(), 20, 2, player.whoAmI);
            }
        }
        if (runePlayer.RunePower >= 2)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }


        }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dustType = 127;
        int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dustType);

        Dust dust = Main.dust[dustIndex];
        dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
        dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HellstoneBar, 20)
        .AddIngredient(ItemID.Obsidian, 20)
        .AddTile(TileID.Anvils)
        .Register();
}