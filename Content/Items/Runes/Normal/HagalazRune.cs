using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class HagalazRune : Rune
{
    public const string RuneName = "Hagalaz";

    private const float MagicDamageBonus = 0.1f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.HagalazDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorHagalazRune>(3)
        .AddIngredient(ItemID.SorcererEmblem)
        .AddIngredient(ItemID.MagicalHarp)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<HagalazEffect>(), new HagalazEffect.Parameters(MagicDamageBonus));
    }
}