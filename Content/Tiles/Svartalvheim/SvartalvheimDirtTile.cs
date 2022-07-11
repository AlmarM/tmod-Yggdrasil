using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.Svartalvheim;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimDirtTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<SvartalvheimStoneTile>()] = true;
		Main.tileBlendAll[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlockLight[Type] = true;

		AddMapEntry(new Color(117, 59, 59));
		ItemDrop = ModContent.ItemType<SvartalvheimDirtBlock>();
		DustType = DustID.Stone;

		MinPick = 210;
		MineResist = 1f;
	}
}