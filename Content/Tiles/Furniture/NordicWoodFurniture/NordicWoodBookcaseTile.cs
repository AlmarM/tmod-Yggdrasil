using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Content.Items.Furniture.NordicWoodFurniture;

namespace Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

public class NordicWoodBookcaseTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolidTop[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.Height = 4;
		TileObjectData.newTile.Width = 3;
		TileObjectData.newTile.CoordinateHeights = new int[]
		{
				16,
				16,
				16,
				16
		};
		TileObjectData.addTile(Type);
		ModTranslation name = CreateMapEntryName();
		DustType = DustID.BorealWood;
		name.SetDefault("Nordic Wood Bookcase");
		AddMapEntry(new Color(55, 49, 47), name);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		TileID.Sets.DisableSmartCursor[Type] = true;
		AdjTiles = new int[] { TileID.Bookcases };
	}

	public override void NumDust(int x, int y, bool fail, ref int num)
	{
		num = fail ? 1 : 3;
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 16, ModContent.ItemType<NordicWoodBookcase>());
	}

}