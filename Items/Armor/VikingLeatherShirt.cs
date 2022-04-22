using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class VikingLeatherShirt : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Viking Leather Shirt");
			Tooltip.SetDefault("2% increased [c/ae804f:runic] damage" + "\n1% increased [c/ae804f:runic] critical strike chance");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 2;
		}
				
		public override void UpdateEquip(Player player) 
		{
			player.GetDamage<RunicDamageClass>() += 0.02f;
			player.GetCritChance<RunicDamageClass>() += 1;	
		}

		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "Linnen", 5)
		.AddTile(TileID.WorkBenches)
        .Register();
	}
}