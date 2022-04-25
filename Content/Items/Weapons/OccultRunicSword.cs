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

public class OccultRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerThreeText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Occult Runic Sword");
        Tooltip.SetDefault($"{runicPowerOneText}: Enables auto swing & increase attack speed" +
                           $"\n{runicPowerThreeText}: Grants +2 {runicText} damage & 5% increased {runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 25;
        Item.crit = 0;
        Item.knockBack = 5;
        Item.value = Item.buyPrice(0, 1, 75);
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>()
        .AddTile(TileID.Anvils)
        .Register();


    public override void HoldItem(Player player)
    {
        Item.autoReuse = false;

        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 1)
        {
            Item.autoReuse = true;
        }
    }

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            crit += 5;
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            flat += 2;
        }
    }

    public override float UseSpeedMultiplier(Player player)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        return runePlayer.RunePower >= 1 ? 1.25f : 1f;
    }
}