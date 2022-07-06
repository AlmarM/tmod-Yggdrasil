using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class MannazRune : Rune<MannazRune>
{
    public const string RuneName = "Mannaz";

    private const float DamageBonus = 0.15f;
    private const float Distance = 500f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.MannazDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorMannazRune>()
        .AddIngredient(ItemID.CrystalVileShard)
        .AddIngredient(ItemID.SoulofMight, 20)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<MannazEffect>(), new MannazEffect.Parameters(DamageBonus, Distance));
    }
}