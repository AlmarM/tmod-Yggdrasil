using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Svartalvheim.Content.Items.Blocks;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimBrickTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{

		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<SvartalvheimDirtTile>()] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileBlendAll[this.Type] = true;
		Main.tileLighted[Type] = true;
		Main.tileBrick[Type] = true;
		TileID.Sets.Conversion.Stone[Type] = true;

		AddMapEntry(new Color(25, 12, 12));

		DustType = DustID.GemRuby;
		ItemDrop = ModContent.ItemType<SvartalvheimStone>();

		MinPick = 210;
		MineResist = 1.1f;
	}

	public override bool CanExplode(int i, int j) => false;
}