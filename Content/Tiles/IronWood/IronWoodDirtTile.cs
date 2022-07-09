using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodDirtTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<IronWoodGrassTile>()] = true;
		Main.tileMerge[Type][ModContent.TileType<IronWoodStoneTile>()] = true;
		Main.tileBlendAll[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlockLight[Type] = true;

		AddMapEntry(new Color(255, 0, 255));
		//AddMapEntry(new Color(91, 84, 71));
		ItemDrop = ModContent.ItemType<IronWoodDirtBlock>();
		DustType = DustID.Stone;


	}
}