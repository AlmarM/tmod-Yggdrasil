using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Items;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class FrostCoreRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("FrostCore Runic Axe");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: Grants +1 {runicText} damage & has 50% chance to inflict frostburn for 1 sec" +
            $"\n{runicPowerTwoText}: Grants +1 {runicText} damage & 2% increased {runicText} critical strike chance" +
            "\nAdds 25% chance to inflict frostburn for 2 more sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.autoReuse = false;
        Item.damage = 20;
        Item.crit = 6;
        Item.knockBack = 6;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 23);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(12)
        .AddTile(TileID.Anvils)
        .Register();

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();

        if (runePlayer.RunePower >= 1)
        {
            flat += 1;
        }

        if (runePlayer.RunePower >= 2)
        {
            flat += 1;
        }
    }

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            crit += 2;
        }
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower < 1)
        {
            return;
        }

        var frostBurnChance = 0.5f;
        int frostBurnDuration = TimeUtils.SecondsToTicks(1);

        if (runePlayer.RunePower >= 2)
        {
            frostBurnChance += .25f;
            frostBurnDuration += TimeUtils.SecondsToTicks(2);
        }

        if (Main.rand.NextFloat() <= frostBurnChance)
        {
            target.AddBuff(BuffID.Frostburn, frostBurnDuration);
        }
    }
}