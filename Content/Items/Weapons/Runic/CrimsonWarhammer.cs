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
using Yggdrasil.Configs;
using Yggdrasil.Utils;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class CrimsonWarhammer : RunicItem
{
    private int FocusValue = 5;
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Crimson Warhammer");

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
            player.AddBuff(ModContent.BuffType<CrimsonBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.CrimtaneBar, 12)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        var runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 4);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Heal for half {runicPowerText} on critical strike to a maximum of 5 \n[c/fc7b03:Focus { FocusValue}]: Increases defense by 4, Grants +10 max life & Increases {runicText} damage by 3";

        return tooltip;
    }

    protected override void AddEffects()
    {
        AddEffect(new RunicCritChanceEffect(2, 5));
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        var healingRunePower = (int)MathF.Min(runePlayer.RunePower / 2f, 5);

        runePlayer.HitCount++; // Needed this because we're overiding OnHitNPC here too

        if (runePlayer.RunePower >= 4)
        {
            if (crit)
            {
                player.statLife += healingRunePower;
                player.HealEffect(healingRunePower);
            }
        }
    }
}