using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class CrimtaneRunicAxe : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Crimtane Axe");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 28;
        Item.crit = 7;
        Item.knockBack = 6;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 27, 0);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.CrimtaneBar, 12)
        .AddTile(TileID.Anvils)
        .Register();

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        var runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        var runePower = string.Format(RuneConfig.RunePowerLabel, 4);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Heal for half {runicPowerText} on critical strike to a maximum of 5";

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