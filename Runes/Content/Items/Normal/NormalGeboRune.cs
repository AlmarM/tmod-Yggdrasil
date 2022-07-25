using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalGeboRune : GeboRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float MinionDamageBonus => 0.1f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorGeboRune>()
        .AddIngredient(ItemID.SummonerEmblem)
        .AddIngredient(ItemID.AncientBattleArmorMaterial)
        .AddTile<DvergrForgeTile>()
        .Register();
}