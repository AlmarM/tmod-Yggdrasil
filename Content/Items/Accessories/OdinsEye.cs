using Terraria;
using Terraria.ID;


using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.Items.Accessories
{
	public class OdinsEye : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Odin's Eye");
			Tooltip.SetDefault("Grants 10% to avoid a fatal blow and heal back to 20% life");
		}

		public override void SetDefaults() 
		{
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)	
		{
			var runePlayer = player.GetModPlayer<RunePlayer>();
			runePlayer.OdinsEye = true;
			
		}
		
	}
}