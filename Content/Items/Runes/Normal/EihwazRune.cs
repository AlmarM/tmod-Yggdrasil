using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class EihwazRune : Rune
{
    public const string RuneName = "Eihwaz";

    private const float MeleeDamageBonus = 0.1f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.EihwazDescription;

    public override int Rarity => ItemRarityID.LightRed;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorEihwazRune>()
        .AddIngredient(ItemID.WarriorEmblem)
        .AddIngredient(ItemID.Chik)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<EihwazEffect>(), new EihwazEffect.Parameters(MeleeDamageBonus));
    }
}