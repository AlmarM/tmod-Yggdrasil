using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Items.Others
{
	public class OccultShard : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Occult Shard");
			Tooltip.SetDefault("A piece of evil");
		}

		public override void SetDefaults() 
		{
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Green;
		}
	}
}