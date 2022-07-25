using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Svartalvheim.Content.Items.Decorations;

namespace Yggdrasil.Content.Tiles.Furniture.SvartalvheimFurniture;

public class SvartalvheimWorkbenchTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolidTop[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileTable[Type] = true;
		Main.tileLavaDeath[Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
		TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Svartalvheim Work Bench");
		AddMapEntry(new Color(92, 42, 42), name);
		TileID.Sets.DisableSmartCursor[Type] = true;
		AdjTiles = new int[] { TileID.WorkBenches };
	}

	public override void NumDust(int x, int y, bool fail, ref int num)
	{
		num = fail ? 1 : 3;
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 16, ModContent.ItemType<SvartalvheimWorkbench>());
	}

}