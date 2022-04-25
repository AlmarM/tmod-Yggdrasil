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

public class FrostCoreRunicHammer : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("FrostCore Runic Axe");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: Grants +3 {runicText} damage & has 50% chance to inflict frostburn for 1 sec" +
            $"\n{runicPowerTwoText}: Increase Size by 50% & adds 25% chance to inflict frostburn for 2 more sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.autoReuse = false;
        Item.damage = 18;
        Item.crit = 0;
        Item.knockBack = 10;
        Item.hammer = 65;
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
            flat += 3;
        }
    }

    public override void HoldItem(Player player)
    {
        Item.scale = 1f;

        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            Item.scale += 0.5f;
        }
    }

    int baseFrostburn = 60; //base Onfire time for the debuff 60 = 1sec
    float baseFrostBurnChance = 0f;

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        float frostBurnProcChance = baseFrostBurnChance;

        if (runePlayer.RunePower >= 1)
        {
            frostBurnProcChance += .5f;
            if (Main.rand.NextFloat() < frostBurnProcChance)
            {
                target.AddBuff(BuffID.Frostburn, baseFrostburn);
            }
        }

        int frostBurnDuration = baseFrostburn;

        if (runePlayer.RunePower >= 2)
        {
            frostBurnProcChance += .25f;
            frostBurnDuration *= 3;

            if (Main.rand.NextFloat() < frostBurnProcChance)
            {
                target.AddBuff(BuffID.Frostburn, frostBurnDuration);
            }
        }
    }
}