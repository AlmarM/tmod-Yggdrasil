using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class BeeRunicAxe : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Queen Bee Axe");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 27;
        Item.crit = 6;
        Item.knockBack = 7;
        Item.axe = 14;
        Item.value = Item.buyPrice(0, 1);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(2, 3));
    }
    protected override string GetTooltip() //Temporary
    {
        string tooltip = base.GetTooltip();
        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 2);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Apply Honey on hit for RunicPower sec"; 

        return tooltip;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            int duration = TimeUtils.SecondsToTicks(runePlayer.RunePower);
            player.AddBuff(BuffID.Honey, duration);
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            damage.Flat += 3;
        }
    }
}