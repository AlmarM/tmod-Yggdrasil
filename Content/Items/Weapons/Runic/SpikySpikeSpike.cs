using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class SpikySpikeSpike : RunicItem
{
    private int FocusValue = 8;
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Spiky Spike Spike");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.autoReuse = true;
        Item.damage = 25;
        Item.crit = 2;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 0, 50);
        Item.rare = ItemRarityID.Green;
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
            player.AddBuff(ModContent.BuffType<SpickySpikeBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 3);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Has 50% on hit to throw a spiky ball \n[c/fc7b03:Focus {FocusValue}]: Grants +100% thorns";

        return tooltip;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {        
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            if (Main.rand.NextFloat() < .5f)
            {
                // @todo clean up in the future
                var x = player.Center.X;
                var y = player.Center.Y;

                var direction = target.Center - player.Center;
                direction.Normalize();

                var speed = 6f;
                float speedX = direction.X * speed;
                float speedY = direction.Y * speed;
                int projectileType = ProjectileID.SpikyBall;
                int projectileDamage = (Item.damage / 2);

                Projectile.NewProjectile(null, x, y, speedX, speedY, projectileType, projectileDamage, 0,
                    player.whoAmI);
            }
        }

        runePlayer.HitCount++;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SpikyBall, 50)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new AttackSpeedEffect(2, 0.25f));
    }
}