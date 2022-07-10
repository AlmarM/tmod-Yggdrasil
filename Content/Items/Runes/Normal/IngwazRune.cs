using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class IngwazRune : Rune<IngwazRune>
{
    public const string RuneName = "Ingwaz";

    private const int HealthBonus = 25;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.IngwazDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorIngwazRune>()
        .AddIngredient(ItemID.LifeFruit)
        .AddIngredient(ItemID.LifeforcePotion, 5)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<IngwazEffect>(), new IngwazEffect.Parameters(HealthBonus));
    }
}