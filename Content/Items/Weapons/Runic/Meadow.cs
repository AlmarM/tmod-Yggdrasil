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

public class Meadow : RunicItem
{
    private int FocusValue = 5;
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerThreeText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Meadow");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: Has 50% chance to inflict poison based on {runicPowerText}" +
            $"\n{runicPowerThreeText} Grants +3 {runicText} damage 2% increased {runicText} critical strike chance" +
            $"\n[c/fc7b03:Focus { FocusValue}]: Increases defense by 5, Incrases {runicText} damage by 3 & 10% increased {runicText} attack speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 1;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
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
        int Time = runePlayer.FocusPowerTime;

        if (runePlayer.HitCount >= FocusValue)
        {
            player.AddBuff(ModContent.BuffType<MeadowBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        int poisonTime = runePlayer.RunePower * 60;

        if (runePlayer.RunePower >= 1)
        {
            if (Main.rand.NextFloat() < 0.5f)
            {
                target.AddBuff(BuffID.Poisoned, poisonTime);
            }
        }

        runePlayer.HitCount++;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            damage.Flat += 3;
        }
    }

    public override void ModifyWeaponCrit(Player player, ref float crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            crit += 2;
        }
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.Stinger, 15)
        .AddIngredient(ItemID.RichMahogany, 10)
        .AddIngredient(ItemID.GoldBar, 6)
        .AddTile<DvergrForgeTile>()
        .Register();

        CreateRecipe()
        .AddIngredient(ItemID.Stinger, 15)
        .AddIngredient(ItemID.RichMahogany, 10)
        .AddIngredient(ItemID.PlatinumBar, 6)
        .AddTile<DvergrForgeTile>()
        .Register();
    }
}