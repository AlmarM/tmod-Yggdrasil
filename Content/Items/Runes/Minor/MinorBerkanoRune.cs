using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorBerkanoRune : Rune
{
    private const int LifeRegenBonus = 5;
    private const int ManaRegenBonus = 20;

    public override string Label => BerkanoRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorBerkanoDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.StarinaBottle, 3)
        .AddIngredient(ItemID.HeartLantern, 3)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<BerkanoEffect>(), new BerkanoEffect.Parameters(LifeRegenBonus, ManaRegenBonus));
    }
}