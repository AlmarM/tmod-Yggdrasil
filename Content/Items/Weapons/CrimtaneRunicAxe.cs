using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class CrimtaneRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");
        string runicPowerFourText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");

        DisplayName.SetDefault("Runic Crimtane Axe");
        Tooltip.SetDefault($"{runicPowerTwoText}: 5% increased {runicText} critical strike chance" +
                           $"\n{runicPowerFourText} Heal for half {runicPowerText} on critical strike to a maximum of 5");

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

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            crit += 5;
        }
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