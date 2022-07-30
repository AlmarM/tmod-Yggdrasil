using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

public class NordicWoodWallTile : YggdrasilWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		ItemDrop = ModContent.ItemType<NordicWoodWall>();
		AddMapEntry(new Color(37, 31, 28));
	}

}