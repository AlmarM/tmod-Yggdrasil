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

public class DemonicWarhammer : RunicItem
{
    private int FocusValue = 5;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Demonic Warhammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 24;
        Item.useAnimation = 24;
        Item.autoReuse = false;
        Item.damage = 20;
        Item.crit = 1;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 0, 27, 0);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void HoldItem(Player player)
    {
        base.HoldItem(player);

        RunePlayer runePlayer = player.GetRunePlayer();

        if (runePlayer.HitCount >= FocusValue)
        {
            //SoundEngine.PlaySound(SoundID.MaxMana, player.Center);  [HELP!] Plays indefinitely, I've no idea how to have it play only once

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
        int Time = runePlayer.FocusPowerTime;

        if (runePlayer.HitCount >= FocusValue)
        {
            player.AddBuff(ModContent.BuffType<DemonicBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 1);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        descriptions.Add($"{runePowerColored}: Spawn a hammer head on critical strike");

        var focus = string.Format(RuneConfig.FocusRequiredLabel, FocusValue);
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, focus);

        string focusLine = $"{focusColored}: ";
        focusLine += "Increases defense by 4, ";
        focusLine += "grants +10% thorns ";
        focusLine += $"and increases {RuneConfig.ColoredRunicDamageLabel} damage by 3";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.DemoniteBar, 12)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new RunicCritChanceEffect(2, 5));
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 4)
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

        var healing = 1;

        runePlayer.HitCount++; // Needed this because we're overiding OnHitNPC here too

        if (runePlayer.RunePower >= 4)
        {
            if (player.statLife < player.statLifeMax2)
            {
                if (Main.rand.NextFloat() < .25f)
                {
                    player.statLife += healing;
                    player.HealEffect(healing);
                }
            }
        }
    }
}