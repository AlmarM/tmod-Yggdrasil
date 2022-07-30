using Terraria;
using Terraria.ID;
using Terraria.ObjectData;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimGlowingStoneTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
		TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
		TileObjectData.newAlternate.AnchorWall = true;
		TileObjectData.addAlternate(0);
		TileObjectData.addTile(Type);

		Main.tileFrameImportant[Type] = true;
		Main.tileSolid[Type] = false;
		Main.tileLighted[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileNoFail[Type] = true;

		//AddMapEntry(new Color(255, 0, 255));
		DustType = DustID.GemRuby;

		MinPick = 210;
		MineResist = 1f;
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		r = 1.5f;
		g = .8f;
		b = .8f;
	}
}