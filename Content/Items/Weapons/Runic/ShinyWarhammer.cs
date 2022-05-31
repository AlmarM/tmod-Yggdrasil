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


namespace Yggdrasil.Content.Items.Weapons.Runic;

public class ShinyWarhammer : RunicItem
{
    private int FocusValue = 5;
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Shiny Warhammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 11;
        Item.crit = 0;
        Item.knockBack = 6;
        Item.axe = 12;
        Item.value = Item.buyPrice(0, 0, 18);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;      
    }

    public override void HoldItem(Player player)
    {
        RunePlayer runePlayer = player.GetRunePlayer();

        if (runePlayer.HitCount >= FocusValue)
        {
            //SoundEngine.PlaySound(SoundID.MaxMana, player.Center);  [HELP!] Plays indefinitely, I've no idea how to have it play only once

            if (Main.rand.NextBool(5)) // Just the never ending sparkle of dusts
            {
                int FocusDust = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 5f), player.width, player.height, DustID.Cloud, //Dust sparkling over the character
                    player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, default(Color), 2f);
                Main.dust[FocusDust].noGravity = true;
                Main.dust[FocusDust].velocity.X *= 0.5f;
                Main.dust[FocusDust].velocity.Y = -2f;
                Main.dust[FocusDust].noLight = true;
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
            player.AddBuff(ModContent.BuffType<ShinyBuff>(), Time);
            player.AddBuff(BuffID.Spelunker, Time);
            //Item.scale *= 2f; [HELP!] This doesn't reset anymore???
            return;
        }
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        tooltip += $"\n[c/fc7b03:Focus {FocusValue}]: Increases defense by 4, Shows ore around you & Grants immunity to certain debuffs";

        return tooltip;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 8)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 8)
            .AddTile(TileID.Anvils)
            .Register();
    }

    protected override void AddEffects()
    {
        AddEffect(new FaintLightEffect(1, new Color(0.4f, 0.4f, 0.1f)));
        AddEffect(new RunicCritChanceEffect(1, 3));
        AddEffect(new AttackSpeedEffect(2, 0.5f));
    }
}