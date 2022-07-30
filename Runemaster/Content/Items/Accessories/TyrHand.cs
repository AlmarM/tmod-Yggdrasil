using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModEffects;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

public class TyrHand : YggdrasilItem
{
    [CloneByReference] private RunicAttackSpeedModEffect _runicAttackSpeedEffect;

    public override void SetStaticDefaults()
    {
        _runicAttackSpeedEffect = new RunicAttackSpeedModEffect(0.1f);

        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Tyr's Hand");
        Tooltip.SetDefault($"{_runicAttackSpeedEffect.EffectDescription}" +
                           $"\n5% increase {runicText} damage" +
                           $"\nIncreases {runicText} weapons range");
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.05f;
        player.GetModPlayer<RunemasterPlayer>().RunicProjectileSpeedMultiplier += 2f;
        player.GetYggdrasilPlayer().AddModHooks(_runicAttackSpeedEffect);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.FeralClaws)
            .AddIngredient(ItemID.ViciousPowder, 5)
            .AddIngredient<BloodDrops>(5)
            .AddTile<DvergrForgeTile>()
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.FeralClaws)
            .AddIngredient(ItemID.VilePowder, 5)
            .AddIngredient<BloodDrops>(5)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}