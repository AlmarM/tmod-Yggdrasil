using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class JeraRune : Rune
{
    public const string RuneName = "Jera";

    private const int AggroReduceBonus = 50;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.JeraDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorJeraRune>()
        .AddIngredient(ItemID.SoulofFright, 10)
        .AddIngredient(ItemID.SoulofNight, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<JeraEffect>(), new JeraEffect.Parameters(AggroReduceBonus));
    }
}