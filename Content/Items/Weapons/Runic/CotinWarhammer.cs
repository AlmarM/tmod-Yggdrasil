using Terraria;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class CotinWarhammer : RunicItem
{
    private int FocusValue = 7;
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Cotin Warhammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.width = 32;
        Item.height = 32;   
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 8;
        Item.crit = 0;
        Item.knockBack = 4;
        Item.value = Item.buyPrice(0, 0, 0, 20);
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
            player.AddBuff(ModContent.BuffType<CotinBuff>(), Time);
            Item.scale *= 2f;

            return;
        }
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        tooltip += $"\n[c/fc7b03:Focus {FocusValue}]: Increases defense by 1, Grants +2 {runicText} damage & 10% increased {runicText} attack speed";

        return tooltip;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.CopperBar, 5)
        .AddTile(TileID.Anvils)
        .Register();

        CreateRecipe()
        .AddIngredient(ItemID.TinBar, 5)
        .AddTile(TileID.Anvils)
        .Register();
    }

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 1));
    }
}