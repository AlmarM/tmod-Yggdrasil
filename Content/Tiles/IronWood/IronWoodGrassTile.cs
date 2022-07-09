using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodGrassTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileSpelunker[Type] = false;
		Main.tileMerge[Type][ModContent.TileType<IronWoodDirtTile>()] = true;
		Main.tileMerge[Type][ModContent.TileType<IronWoodStoneTile>()] = true;
		Main.tileBlendAll[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlockLight[Type] = true;
		TileID.Sets.Conversion.Grass[Type] = true;
		//PlantLoader.GetModTreeType(ModContent.TryFind<IronWoodTree>();
		AddMapEntry(new Color(120, 111, 105));

		DustType = DustID.Stone;
		ItemDrop = ModContent.ItemType<IronWoodDirtBlock>();
	}

	public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
	{
		TileObject toBePlaced;
		if (!TileObject.CanPlace(x, y, type, style, direction, out toBePlaced, false))
		{
			return false;
		}
		toBePlaced.random = random;
		if (TileObject.Place(toBePlaced) && !mute)
		{
			WorldGen.SquareTileFrame(x, y, true);
			//   Main.PlaySound(SoundID.Dig, x * 16, y * 16, 1, 1f, 0f);
		}
		return false;
	}


	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile2 = Framing.GetTileSafely(i, j - 1);
		if (!Main.tileSolid[tile2.TileType] || !tile2.HasTile)
		{
			r = 0.5f;
			g = 0.6f;
			b = 0.5f;
		}
	}
}