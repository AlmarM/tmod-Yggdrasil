using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class PerthroRune : Rune
{
    public const string RuneName = "Perthro";

    private const float ApplyBuffChance = 0.05f;
    private const float BuffDuration = 5;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.PerthroDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorPerthroRune>()
        .AddIngredient(ItemID.FlowerofFrost)
        .AddIngredient(ItemID.FlaskofVenom, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<PerthroEffect>(), new PerthroEffect.Parameters(ApplyBuffChance, BuffDuration));
    }
}