using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class DagazRune : Rune
{
    public const string RuneName = "Dagaz";

    private const float RangeDamageBoost = 0.1f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.DagazDescription;

    public override int Rarity => ItemRarityID.LightRed;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorDagazRune>(3)
        .AddIngredient(ItemID.RangerEmblem)
        .AddIngredient(ItemID.MagicQuiver)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<DagazEffect>(), new DagazEffect.Parameters(RangeDamageBoost));
    }
}