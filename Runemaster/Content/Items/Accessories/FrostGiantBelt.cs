using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Extensions;
using Yggdrasil.ModEffects;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

public class FrostGiantBelt : YggdrasilItem
{
    private BlizzardExplosionModEffect _blizzardExplosionEffect;

    public override ModItem Clone(Item newEntity)
    {
        var clone = (FrostGiantBelt)base.Clone(newEntity);
        clone.SetupData(newEntity);

        return clone;
    }

    protected override void SetupData(Item item)
    {
        _blizzardExplosionEffect = new BlizzardExplosionModEffect(item);
    }

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Frost Giant Belt");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\n5% increased {runicText} critical strike chance" +
                           "\nIncrease defense by 5 in snow biome" +
                           "\nProvides life regeneration in snow biome" +
                           "\nGrants immunity to fire blocks" +
                           $"\n{_blizzardExplosionEffect.EffectDescription}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.fireWalk = true;
        player.GetDamage<RunicDamageClass>() += 0.1f;
        player.GetCritChance<RunicDamageClass>() += 5;
        player.GetYggdrasilPlayer().AddModHooks(_blizzardExplosionEffect);

        if (player.ZoneSnow)
        {
            player.statDefense += 5;
            player.lifeRegen += 5;
        }
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostGiantHand>()
        .AddIngredient<FrostGiantShard>()
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}