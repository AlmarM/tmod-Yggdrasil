using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorKenazRune : Rune
{
    private const float DodgeChanceBonus = 0.03f;

    public override string Label => KenazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorKenazDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<KenazRune>()
        .AddIngredient(ItemID.Tabi)
        .AddIngredient(ItemID.BlackBelt)
        .AddIngredient(ItemID.BlackFairyDust)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<KenazEffect>(), new KenazEffect.Parameters(DodgeChanceBonus));
    }
}