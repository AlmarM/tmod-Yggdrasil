using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class NauthizRune : Rune
{
    public const string RuneName = "Nauthiz";

    private const float InvincibilityBonus = 0.25f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.NauthizDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorNauthizRune>()
        .AddIngredient(ItemID.CrossNecklace)
        .AddIngredient(ItemID.SoulofMight, 5)
        .AddIngredient(ItemID.SoulofFright, 5)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<NauthizEffect>(), new NauthizEffect.Parameters(InvincibilityBonus));
    }
}