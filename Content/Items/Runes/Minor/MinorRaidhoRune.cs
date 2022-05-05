/*using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorRaidhoRune : Rune
{
    private const float ThrowingDamageBonus = 0.05f;

    public override string Label => RaidhoRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorRaidhoDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.FossilOre, 25)
        .AddIngredient(ItemID.Javelin, 100)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<RaidhoEffect>(), new RaidhoEffect.Parameters(ThrowingDamageBonus));
    }
}*/