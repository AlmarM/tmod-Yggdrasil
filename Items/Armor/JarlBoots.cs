using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class JarlBoots : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Jarl Boots");
			Tooltip.SetDefault("2% increased [c/ae804f:runic] damage" + "\n8% increase movement speed");
		}

		public override void SetDefaults() 
		{
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;
            Item.value = Item.sellPrice(0, 30, 0, 0);
		}

		public override void UpdateEquip(Player player) 
		{
			player.moveSpeed += 0.08f;
			player.GetDamage<RunicDamageClass>() += 0.02f;
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