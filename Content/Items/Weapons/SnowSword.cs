using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Weapons
{
	public class SnowSword : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snow Sword");
			Tooltip.SetDefault("It's made out of snow!");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 0, 40);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Swing; 
		}

		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SnowBlock, 25)
        .Register();
	}
}
