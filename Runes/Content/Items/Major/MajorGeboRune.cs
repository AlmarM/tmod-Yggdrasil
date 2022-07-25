using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorGeboRune : GeboRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float MinionDamageBonus => 0.2f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalGeboRune>()
        .AddIngredient(ItemID.SpookyWood, 400)
        .AddIngredient(ItemID.PygmyNecklace)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}