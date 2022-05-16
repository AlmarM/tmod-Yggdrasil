using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorNauthizRune : Rune
{
    private const float InvincibilityBonus = 0.1f;

    public override string Label => NauthizRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorNauthizDescription;

    public override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.HoneyComb)
        .AddIngredient(ItemID.GuideVoodooDoll)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<NauthizEffect>(), new NauthizEffect.Parameters(InvincibilityBonus));
    }
}