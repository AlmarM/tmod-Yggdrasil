using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Extensions;
using Yggdrasil.ModEffects;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

public class TwoWorldsBelt : YggdrasilItem
{
    [CloneByReference] private BlizzardExplosionModEffect _blizzardExplosionEffect;

    public override void SetStaticDefaults()
    {
        _blizzardExplosionEffect = new BlizzardExplosionModEffect(Item);

        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Two Worlds Belt");
        Tooltip.SetDefault("Merging the essence of two worlds create something truly unbelievable" +
                           $"\n25% increased {runicText} damage" +
                           $"\n5% increased {runicText} critical strike chance" +
                           "\nIncrease defense by 5" +
                           "\nProvides life regeneration" +
                           "\nGrants immunity to fire blocks" +
                           $"\n{_blizzardExplosionEffect.EffectDescription}" +
                           "\nIncrease max life by 20" +
                           "\nGrants immunity to OnFire, Shadowflame, Frostburn, Chilled and Frozen" +
                           "\nGrants immunity to fire blocks and lava" +
                           "\nIgnites nearby enemies");

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
        player.GetCritChance<RunicDamageClass>() += 5;
        player.AddBuff(BuffID.Inferno, 2);

        player.statDefense += 5;
        player.lifeRegen += 5;
        player.fireWalk = true;

        player.lavaImmune = true;
        player.fireWalk = true;
        player.statLifeMax2 += 20;
        player.buffImmune[BuffID.Burning] = true;
        player.buffImmune[BuffID.OnFire] = true;
        player.buffImmune[BuffID.Chilled] = true;
        player.buffImmune[BuffID.Frozen] = true;
        player.buffImmune[BuffID.ShadowFlame] = true;
        player.buffImmune[BuffID.Frostburn] = true;

        player.GetYggdrasilPlayer().AddModHooks(_blizzardExplosionEffect);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostGiantBelt>()
        .AddIngredient<SurtrBelt>()
        .AddIngredient<TrueHeroFragment>()
        .AddIngredient(ItemID.FragmentSolar, 5)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}