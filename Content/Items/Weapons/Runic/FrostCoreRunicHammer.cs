using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class FrostCoreRunicHammer : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        // string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        // string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        // string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("Runic FrostCore Warhammer");
        // Tooltip.SetDefault(
        //     $"{runicPowerOneText}: Grants +3 {runicText} damage & has 50% chance to inflict frostburn for 1 sec" +
        //     $"\n{runicPowerTwoText}: Increase Size by 50% & adds 25% chance to inflict frostburn for 2 more sec");

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
        //Item.hammer = 65;
        Item.value = Item.buyPrice(0, 0, 23);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(8)
        .AddTile(TileID.Anvils)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 3));
        AddEffect(new InflictBuffEffect(1, BuffID.Frostburn, 1, "Frostburn", 0.5f, true));
        AddEffect(new BiggerSizeEffect(2, 0.5f));
        AddEffect(new InflictBuffEffect(2, BuffID.Frostburn, 2, "Frostburn", 0.25f, true));
    }
}