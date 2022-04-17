using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class RaidhoRune : Rune
{
    public const string RuneName = "Raidho";

    private const float ThrowingDamageBonus = 0.1f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.RaidhoDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorRaidhoRune>(3)
        .AddIngredient(ItemID.LightDisc)
        .AddIngredient(ItemID.MagicDagger)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<RaidhoEffect>(), new RaidhoEffect.Parameters(ThrowingDamageBonus));
    }
}