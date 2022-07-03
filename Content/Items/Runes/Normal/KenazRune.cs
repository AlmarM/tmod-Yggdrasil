using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class KenazRune : Rune
{
    public const string RuneName = "Kenaz";

    private const float DodgeChanceBonus = 0.02f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.KenazDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorKenazRune>()
        .AddIngredient(ItemID.SmokeBomb, 10)
        .AddIngredient(ItemID.SoulofSight, 10)
        .AddIngredient(ItemID.DarkShard, 2)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<KenazEffect>(), new KenazEffect.Parameters(DodgeChanceBonus));
    }
}