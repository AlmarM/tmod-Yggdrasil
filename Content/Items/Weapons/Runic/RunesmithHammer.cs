using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class RunesmithHammer : RunicItem
{
    private int FocusValue = 5;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runesmith Warhammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 9;
        Item.crit = 0;
        Item.knockBack = 5;
        //Item.hammer = 45;
        Item.value = Item.buyPrice(0, 0, 5, 40);
        Item.rare = ItemRarityID.White;
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
            player.AddBuff(ModContent.BuffType<RunesmithBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focus = string.Format(RuneConfig.FocusRequiredLabel, FocusValue);
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, focus);

        string focusLine = $"{focusColored}: ";
        focusLine += "Increases defense by 3, ";
        focusLine += "and slowly regenerates life";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 5)
        .AddRecipeGroup(RecipeGroupID.IronBar, 8)
        .AddTile(TileID.Anvils)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 3));
    }
}