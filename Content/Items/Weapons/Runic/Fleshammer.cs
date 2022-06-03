using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;
using Yggdrasil.Extensions;
using Yggdrasil.Content.Buffs;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class Fleshammer : RunicItem
{
    private int FocusValue = 5;
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Fleshammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.autoReuse = false;
        Item.damage = 36;
        Item.crit = 2;
        Item.knockBack = 7;
        Item.value = Item.buyPrice(0, 1, 25);
        Item.rare = ItemRarityID.LightRed;
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
            player.AddBuff(ModContent.BuffType<FleshBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        tooltip += $"\n[c/fc7b03:Focus {FocusValue}]: Increases defense by 8, Grants +20 max life & Regenerates life";

        return tooltip;
    }

    protected override void AddEffects()
    {
        AddEffect(new AutoReuseEffect(2));
        AddEffect(new FlatRunicDamageEffect(3, 2));
        AddEffect(new BiggerSizeEffect(7, 0.25f));
        AddEffect(new InflictBuffEffect(5, ModContent.BuffType<SlowDebuff>(), .5f, "Slow", 1f, true));
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dustType = 5; //Blood
        int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dustType);

        Dust dust = Main.dust[dustIndex];
        dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
        dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
    }

    // Dropped by Wall of Flesh
}