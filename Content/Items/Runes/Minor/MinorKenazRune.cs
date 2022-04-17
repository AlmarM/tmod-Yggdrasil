using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorKenazRune : Rune
{
    private const float DodgeChanceBonus = 0.01f;

    public override string Label => KenazRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorKenazDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>(10)
        .AddIngredient(ItemID.NinjaHood)
        .AddIngredient(ItemID.InvisibilityPotion, 5)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<KenazEffect>(), new KenazEffect.Parameters(DodgeChanceBonus));
    }
}