using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class ThurisazRune : Rune<ThurisazRune>
{
    public const string RuneName = "Thurisaz";

    private const float ThornsBonus = 0.25f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.ThurisazDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorThurisazRune>()
        .AddIngredient(ItemID.TurtleShell)
        .AddIngredient(ItemID.Spike, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<ThurisazEffect>(), new ThurisazEffect.Parameters(ThornsBonus));
    }
}