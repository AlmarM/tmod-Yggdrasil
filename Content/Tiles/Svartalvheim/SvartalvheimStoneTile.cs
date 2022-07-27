using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.World.Svartalvheim.Content.Items.Blocks;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimStoneTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{

		Main.tileSpelunker[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileMerge[Type][ModContent.TileType<SvartalvheimDirtTile>()] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileBlendAll[this.Type] = true;
		Main.tileLighted[Type] = true;
		TileID.Sets.Conversion.Stone[Type] = true;

		AddMapEntry(new Color(64, 30, 30));

		DustType = DustID.GemRuby;
		ItemDrop = ModContent.ItemType<SvartalvheimStone>();

		MinPick = 210;
		MineResist = 1.1f;
	}

	public override bool CanExplode(int i, int j) => false;
}