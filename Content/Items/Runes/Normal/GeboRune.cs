using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class GeboRune : Rune
{
    public const string RuneName = "Gebo";

    private const float MinionDamageBonus = 0.1f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.GeboDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorGeboRune>(3)
        .AddIngredient(ItemID.SummonerEmblem)
        .AddIngredient(ItemID.AncientBattleArmorMaterial)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<GeboEffect>(), new GeboEffect.Parameters(MinionDamageBonus));
    }
}