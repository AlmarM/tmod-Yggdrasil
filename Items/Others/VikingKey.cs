using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Others
{
	public class VikingKey : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Viking Key");
			Tooltip.SetDefault("A cold key");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Yellow;
		}

	}
}