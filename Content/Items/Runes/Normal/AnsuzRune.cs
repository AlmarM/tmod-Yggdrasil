using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class AnsuzRune : Rune
{
    public const string RuneName = "Ansuz";

    private const int MaxManaBonus = 20;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.AnsuzDescription;

    public override int Rarity => ItemRarityID.Orange;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorAnsuzRune>()
        .AddIngredient(ItemID.NaturesGift)
        .AddIngredient(ItemID.CrystalBall)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<AnsuzEffect>(), new AnsuzEffect.Parameters(MaxManaBonus));
    }
}