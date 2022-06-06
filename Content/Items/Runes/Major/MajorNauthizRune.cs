using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorNauthizRune : Rune
{
    private const float InvincibilityBonus = 0.5f;

    public override string Label => NauthizRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorNauthizDescription;

    public override int Rarity => ItemRarityID.Red;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NauthizRune>()
        .AddIngredient(ItemID.MartianConduitPlating, 50)
        .AddIngredient(ItemID.Ectoplasm, 10)
        .AddIngredient(ItemID.FragmentVortex, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<NauthizEffect>(), new NauthizEffect.Parameters(InvincibilityBonus));
    }
}