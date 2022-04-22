using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class JarlShirt : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Jarl Shirt");
			Tooltip.SetDefault("5% increased [c/ae804f:runic] critical strike chance");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}
				
		public override void UpdateEquip(Player player) 
		{
			player.GetCritChance<RunicDamageClass>() += 5;	
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(Mod, "Linnen", 10)
			.AddIngredient(ItemID.GoldBar, 10)
			.AddTile(TileID.Anvils)
			.Register();

			CreateRecipe()
			.AddIngredient(Mod, "Linnen", 10)
			.AddIngredient(ItemID.PlatinumBar, 10)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}