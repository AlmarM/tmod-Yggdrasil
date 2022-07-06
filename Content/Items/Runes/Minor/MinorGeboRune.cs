using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorGeboRune : Rune<MinorGeboRune>
{
    private const float MinionDamageBonus = 0.05f;

    public override string Label => GeboRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorGeboDescription;

    public override int Rarity => ItemRarityID.Orange;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.BeeWax, 30)
        .AddIngredient(ItemID.ImpStaff)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<GeboEffect>(), new GeboEffect.Parameters(MinionDamageBonus));
    }
}