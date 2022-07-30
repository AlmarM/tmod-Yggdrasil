using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Consumables;

public class MoldyCheeseSoup : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moldy Cheese Soup");

        Tooltip.SetDefault("Medium  improvements to all stats\nAre you seriously going to eat that?");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

	public override void SetDefaults()
	{
		Item.rare = ItemRarityID.Blue;
		Item.maxStack = 99;
		Item.noUseGraphic = true;
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useTime = Item.useAnimation = 30;
		Item.value = Item.sellPrice(0, 0, 0, 10);

		Item.buffType = BuffID.WellFed2;
		Item.buffTime = 36000;
		Item.noMelee = true;
		Item.consumable = true;
		Item.UseSound = SoundID.Item2;
		Item.autoReuse = false;
	}

    public override void OnConsumeItem(Player player)
    {
		player.AddBuff(BuffID.Poisoned, 600);
		player.AddBuff(BuffID.Stinky, 18000);
		player.AddBuff(BuffID.WeaponImbueIchor, 36000);
	}

	public override void AddRecipes() => CreateRecipe()
		.AddIngredient<MoldyCheese>()
		.AddIngredient(ItemID.Bowl)
		.AddIngredient(ItemID.BottledWater)
		.AddTile(TileID.CookingPots)
		.Register();

}