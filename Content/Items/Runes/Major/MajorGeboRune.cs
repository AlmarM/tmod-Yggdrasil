using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorGeboRune : Rune
{
    private const float MinionDamageBonus = 0.2f;

    public override string Label => GeboRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorGeboDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<GeboRune>(3)
        .AddIngredient(ItemID.SpookyWood, 400)
        .AddIngredient(ItemID.PygmyNecklace)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<GeboEffect>(), new GeboEffect.Parameters(MinionDamageBonus));
    }
}