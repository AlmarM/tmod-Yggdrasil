using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Yggdrasil.Items.Consumables
{
	public class RunicPotion : YggdrasilItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("20% increased runic damage");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 0, 2, 0);
			Item.buffType = ModContent.BuffType<Buffs.RunicBuff>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 14400; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "BlankRune")
		.AddIngredient(ItemID.Shiverthorn)
		.AddTile(TileID.Bottles)
        .Register();
	}
}