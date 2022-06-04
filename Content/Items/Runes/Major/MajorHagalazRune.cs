using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorHagalazRune : Rune
{
    private const float MagicDamageBonus = 0.2f;

    public override string Label => HagalazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorHagalazDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<HagalazRune>()
        .AddIngredient(ItemID.StaffofEarth)
        .AddIngredient(ItemID.RazorbladeTyphoon)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<HagalazEffect>(), new HagalazEffect.Parameters(MagicDamageBonus));
    }
}