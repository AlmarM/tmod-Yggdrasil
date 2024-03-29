using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorWunjoRune : Rune<MinorWunjoRune>
{
    private const float DamageReductionBonus = 0.03f;

    public override string Label => WunjoRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorWunjoDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.AncientNecroHelmet)
        .AddIngredient(ItemID.SkeletronTrophy)
        .AddIngredient(ItemID.HellstoneBar, 20)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<WunjoEffect>(), new WunjoEffect.Parameters(DamageReductionBonus));
    }
}