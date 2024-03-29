using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorBerkanoRune : Rune<MinorBerkanoRune>
{
    private const int LifeRegenBonus = 3;
    private const int ManaRegenBonus = 3;

    public override string Label => BerkanoRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorBerkanoDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.StarinaBottle, 3)
        .AddIngredient(ItemID.HeartLantern, 3)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<BerkanoEffect>(), new BerkanoEffect.Parameters(LifeRegenBonus, ManaRegenBonus));
    }
}