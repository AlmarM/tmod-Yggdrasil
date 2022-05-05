/*using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorRaidhoRune : Rune
{
    private const float ThrowingDamageBonus = 0.2f;

    public override string Label => RaidhoRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorRaidhoDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RaidhoRune>(3)
        .AddIngredient(ItemID.PaladinsHammer)
        .AddIngredient(ItemID.ToxicFlask)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<RaidhoEffect>(), new RaidhoEffect.Parameters(ThrowingDamageBonus));
    }
}*/