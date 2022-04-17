using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorPerthroRune : Rune
{
    private const float ApplyBuffChance = 0.01f;
    private const float BuffDuration = 2;

    public override string Label => PerthroRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorPerthroDescription;

    public override int Rarity => ItemRarityID.LightRed;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>(10)
        .AddIngredient(ItemID.LavaBucket)
        .AddIngredient(ItemID.FlaskofFire, 10)
        .AddIngredient(ItemID.FlaskofPoison, 10)
        .Register();

    protected override void AddEffects()
    {
    }
}