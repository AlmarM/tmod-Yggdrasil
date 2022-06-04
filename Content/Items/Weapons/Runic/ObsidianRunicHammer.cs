using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class ObsidianRunicHammer : RunicItem
{
    private int FocusValue = 5;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Obsidian Warhammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.autoReuse = false;
        Item.damage = 30;
        Item.crit = 1;
        Item.knockBack = 7;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
        Item.scale = 1.5f;
    }

    public override void HoldItem(Player player)
    {
        base.HoldItem(player);

        RunePlayer runePlayer = player.GetRunePlayer();

        if (runePlayer.HitCount >= FocusValue)
        {
            //SoundEngine.PlaySound(SoundID.MaxMana, player.Center);

            // Just the never ending sparkle of dusts
            if (Main.rand.NextBool(5))
            {
                var position = new Vector2(player.position.X, player.position.Y + 5f);
                var velocityX = player.velocity.X * 0.5f;
                var velocityY = player.velocity.Y * 0.5f;

                //Dust sparkling over the character
                int focusDust = Dust.NewDust(position, player.width, player.height, DustID.Cloud, velocityX, velocityY,
                    100, default, 2f);

                Main.dust[focusDust].noGravity = true;
                Main.dust[focusDust].velocity.X *= 0.5f;
                Main.dust[focusDust].velocity.Y = -2f;
                Main.dust[focusDust].noLight = true;
            }
        }
    }

    public override bool AltFunctionUse(Player player)
    {
        RunePlayer runePlayer = player.GetRunePlayer();

        if (runePlayer.HitCount >= FocusValue)
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

            player.GetRunePlayer().HitCount = 0;

            return true;
        }

        return base.UseItem(player);
    }

    protected virtual void OnRightClick(Player player)
    {
        RunePlayer runePlayer = player.GetRunePlayer();
        int time = runePlayer.FocusPowerTime;

        if (runePlayer.HitCount >= FocusValue)
        {
            player.AddBuff(ModContent.BuffType<ObsidianBuff>(), time);
            Item.scale *= 2f;

            return;
        }
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        base.OnHitNPC(player, target, damage, knockback, crit);

        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 4)
        {
            const float projectileSpeed = 6f;
            const float radius = 25f;

            int projectileCount = (int)MathF.Min(runePlayer.RunePower, 6);
            int projectileType = ModContent.ProjectileType<FireProjectile>();
            float delta = MathF.PI * 2 / projectileCount;

            for (var i = 0; i < projectileCount; i++)
            {
                float theta = delta * i;
                var position = target.Center + Vector2.One.RotatedBy(theta) * radius;

                Vector2 direction = position - target.Center;
                direction = Vector2.Normalize(direction);
                direction = Vector2.Multiply(direction, projectileSpeed);

                Projectile.NewProjectile(null, position, direction, projectileType, 20, 2, player.whoAmI);
            }
        }
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 4);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        descriptions.Add($"{runePowerColored}: Spawn fireballs on hit");

        var focus = string.Format(RuneConfig.FocusRequiredLabel, FocusValue);
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, focus);

        string focusLine = $"{focusColored}: ";
        focusLine += "Increases defense by 7, ";
        focusLine += $"5% increased {RuneConfig.ColoredRunicDamageLabel} critical strike chance ";
        focusLine += $"and grants immunity to fire blocks and lava";

        descriptions.Add(focusLine);

        return descriptions;
    }

    protected override void AddEffects()
    {
        AddEffect(new BiggerSizeEffect(2, 0.5f));
        AddEffect(new InflictBuffEffect(2, BuffID.OnFire, 3, "OnFire", 1f, true));
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
        .AddTile<DvergrForgeTile>()
        .Register();
}