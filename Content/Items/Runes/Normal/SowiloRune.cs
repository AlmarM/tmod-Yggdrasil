using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class SowiloRune : Rune<SowiloRune>
{
    public const string RuneName = "Sowilo";

    private const int ArmorPenetrationBonus = 3;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.SowiloDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorSowiloRune>()
        .AddIngredient(ItemID.UnicornHorn, 10)
        .AddIngredient(ItemID.Drax)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<SowiloEffect>(), new SowiloEffect.Parameters(ArmorPenetrationBonus));
    }
}