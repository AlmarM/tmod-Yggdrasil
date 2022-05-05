using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Weapons.Snow
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
			Item.damage = 9;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.knockBack = 2;
			Item.crit = 0;
			Item.value = Item.sellPrice(0, 0, 0, 20);
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
