using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimGrassTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<SvartalvheimDirtTile>()] = true;
		Main.tileBlendAll[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlockLight[Type] = true;

		AddMapEntry(new Color(74, 74, 114));
		//ItemDrop = ModContent.ItemType<SvartalvheimDirtBlock>();
		DustType = DustID.GemRuby;

		MinPick = 210;
		MineResist = 1f;
	}

	public override bool CanExplode(int i, int j) => false;
}