using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class TwoWorldsBelt : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Two Worlds Belt");
        Tooltip.SetDefault("Merging the essence of two worlds create something truly unbelievable" +
                           $"\n25% increased {runicText} damage" +
                           $"\n5% increased { runicText} critical strike chance" +
                           $"\nIncrease defense by 5" +
                           $"\nProvides life regeneration" +
                           $"\nGrants immunity to fire blocks" +
                           $"\nCritical hit caused by {runicText} weapons releases many frost sparks" +
                           "\nIncrease max life by 20" +
                           "\nGrants immunity to OnFire, Shadowflame, Frostburn, Chilled and Frozen" +
                           "\nGrants immunity to fire blocks and lava" +
                           $"\nIgnites nearby enemies");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 10);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.25f;
        player.statDefense += 5;
        player.lifeRegen += 5;
        player.GetCritChance<RunicDamageClass>() += 5;
        player.SetEffect<FrostGiantHand>();
        player.fireWalk = true;
        player.AddBuff(BuffID.Inferno, 2);

        player.lavaImmune = true;
        player.fireWalk = true;
        player.statLifeMax2 += 20;
        player.buffImmune[BuffID.Burning] = true;
        player.buffImmune[BuffID.OnFire] = true;
        player.buffImmune[BuffID.Chilled] = true;
        player.buffImmune[BuffID.Frozen] = true;
        player.buffImmune[BuffID.ShadowFlame] = true;
        player.buffImmune[BuffID.Frostburn] = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostGiantBelt>()
        .AddIngredient<SurtrBelt>()
        .AddIngredient<TrueHeroFragment>()
        .AddIngredient(ItemID.FragmentSolar, 5)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}