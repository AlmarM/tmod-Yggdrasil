using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodIceTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{

		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<IronWoodStoneTile>()] = true;
		Main.tileMerge[Type][ModContent.TileType<IronWoodDirtTile>()] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileBlendAll[this.Type] = true;
		Main.tileLighted[Type] = true;
		TileID.Sets.Conversion.Stone[Type] = true;

		AddMapEntry(new Color(199, 210, 215));

		DustType = DustID.Stone;
		ItemDrop = ModContent.ItemType<IronWoodIce>();


	}
}