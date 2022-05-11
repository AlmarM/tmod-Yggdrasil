using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class FleshRunicAxe : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Fleshy Axe");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 36;
        Item.crit = 6;
        Item.knockBack = 7;
        Item.axe = 14;
        Item.value = Item.buyPrice(0, 1, 25);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }
    /*protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        var runePower = string.Format(RuneConfig.RunePowerLabel, 5);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored} Hitting an enemy slows the target for half a sec";

        return tooltip;
    }*/
    protected override void AddEffects()
    {
        AddEffect(new AutoReuseEffect(2));
        AddEffect(new FlatRunicDamageEffect(3, 2));
        AddEffect(new BiggerSizeEffect(7, 0.25f));
        AddEffect(new InflictBuffEffect(5, ModContent.BuffType<SlowDebuff>(), .5f, "Slow", 1f, true));
    }

    /*public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 5)
        {
            target.AddBuff(ModContent.BuffType<SlowDebuff>(), 30);
        }
    }*/
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