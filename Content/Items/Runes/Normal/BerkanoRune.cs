using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class BerkanoRune : Rune
{
    public const string RuneName = "Berkano";

    private const int LifeRegenBonus = 5;
    private const int ManaRegenBonus = 5;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.BerkanoDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorBerkanoRune>()
        .AddIngredient(ItemID.MoonStone)
        .AddIngredient(ItemID.LifeFruit, 2)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<BerkanoEffect>(), new BerkanoEffect.Parameters(LifeRegenBonus, ManaRegenBonus));
    }
}