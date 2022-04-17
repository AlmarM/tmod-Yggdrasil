using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorJeraRune : Rune
{
    private const int AggroReduceBonus = 20;

    public override string Label => JeraRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorJeraDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>(10)
        .AddIngredient(ItemID.InvisibilityPotion, 5)
        .AddIngredient(ItemID.Shiverthorn, 5)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<JeraEffect>(), new JeraEffect.Parameters(AggroReduceBonus));
    }
}