using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodStoneTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{

		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<IronWoodDirtTile>()] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileBlendAll[this.Type] = true;
		Main.tileLighted[Type] = true;
		TileID.Sets.Conversion.Stone[Type] = true;

		AddMapEntry(new Color(144, 134, 130));

		DustType = DustID.Stone;
		ItemDrop = ModContent.ItemType<IronWoodStone>();


	}
}