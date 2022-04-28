using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorAnsuzRune : Rune
{
    private const int MaxManaBonus = 10;

    public override string Label => AnsuzRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorAnsuzDescription;

    public override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.ManaCrystal, 5)
        .AddIngredient(ItemID.BandofStarpower)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<AnsuzEffect>(), new AnsuzEffect.Parameters(MaxManaBonus));
    }
}