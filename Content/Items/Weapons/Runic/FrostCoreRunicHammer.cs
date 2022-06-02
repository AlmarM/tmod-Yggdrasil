using Terraria;
using Microsoft.Xna.Framework;
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
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class FrostCoreRunicHammer : RunicItem
{
    private int FocusValue = 7;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        // string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        // string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        // string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("Frostcore Warhammer");
        // Tooltip.SetDefault(
        //     $"{runicPowerOneText}: Grants +3 {runicText} damage & has 50% chance to inflict frostburn for 1 sec" +
        //     $"\n{runicPowerTwoText}: Increase Size by 50% & adds 25% chance to inflict frostburn for 2 more sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 24;
        Item.useAnimation = 24;
        Item.autoReuse = false;
        Item.damage = 18;
        Item.crit = 0;
        Item.knockBack = 5;
        Item.value = Item.buyPrice(0, 0, 23);
        Item.rare = ItemRarityID.Blue;
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
        int time = runePlayer.FocusPowerTime;

        if (runePlayer.HitCount >= FocusValue)
        {
            player.AddBuff(ModContent.BuffType<FrostcoreBuff>(), time);
            Item.scale *= 2f;

            return;
        }
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        tooltip +=
            $"\n[c/fc7b03:Focus {FocusValue}]: Increases defense by 4, Slowly regenerates life & Grants immunity to certain debuffs";

        return tooltip;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(8)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 3));
        AddEffect(new InflictBuffEffect(1, BuffID.Frostburn, 1, "Frostburn", 0.5f, true));
        AddEffect(new BiggerSizeEffect(2, 0.5f));
        AddEffect(new InflictBuffEffect(2, BuffID.Frostburn, 2, "Frostburn", 0.25f, true));
    }
}