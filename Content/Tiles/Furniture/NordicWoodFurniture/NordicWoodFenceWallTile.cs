using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Nordic.Content.Items.Decorations;

namespace Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

public class NordicWoodFenceWallTile : YggdrasilWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		ItemDrop = ModContent.ItemType<NordicWoodFenceWall>();
		AddMapEntry(new Color(55, 49, 47));
	}

}