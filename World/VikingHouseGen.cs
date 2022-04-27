using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.World
{
	public class VikingHouseGen : StructureGen
	{
		public override int OffsetX => -3;
		public override int OffsetY => -16;
		public override int[,] Tiles => new int[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,3,3,3,6,6,6,0,0,0,0,3,3,3,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,3,3,4,6,0,0,0,0,0,0,4,3,3,3,0,0,0,0,0,0},
			{0,0,0,0,0,0,3,3,3,0,4,0,0,0,0,0,0,0,4,0,3,3,3,0,0,0,0,0},
			{0,0,0,0,0,3,3,3,0,0,4,0,0,0,0,0,0,0,4,0,0,3,3,3,0,0,0,0},
			{0,0,0,0,3,3,3,3,3,3,3,3,3,0,0,0,3,3,3,3,3,3,3,3,0,0,0,0},
			{0,0,0,3,3,3,6,3,4,0,0,0,0,0,0,0,0,0,6,6,4,3,0,0,0,0,0,0},
			{0,0,0,3,3,0,6,3,4,0,0,0,0,0,0,0,0,0,0,0,4,3,0,0,0,0,0,0},
			{0,0,0,3,3,3,3,3,4,0,0,0,0,0,0,0,0,0,0,0,4,3,0,0,0,0,0,0},
			{0,0,0,0,4,0,3,3,4,0,0,0,0,0,0,0,0,0,0,0,4,3,0,0,0,0,0,0},
			{0,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0},
			{0,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0},
			{0,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0},
			{0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0},
			{0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
			{0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0},
			{0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0}
		};
		public override int[,] Slopes => new int[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,2,0,3,0,0,0,0,0,0,0,0,0,4,0,1,0,0,0,0,0,0},
			{0,0,0,0,0,0,2,0,3,0,0,0,0,0,0,0,0,0,0,0,4,0,1,0,0,0,0,0},
			{0,0,0,0,0,2,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,1,0,0,0,0},
			{0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,2,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
		};
		public override int[,] Walls => new int[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,1,1,1,3,3,3,1,1,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,1,1,1,1,3,3,3,1,1,1,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,1,1,1,1,1,3,3,3,1,1,1,1,1,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,1,1,1,1,1,1,3,3,3,1,1,1,1,1,1,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,8,8,8,8,8,3,3,3,8,8,8,8,8,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,1,0,8,8,8,8,8,3,3,3,8,8,8,8,8,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,1,0,8,8,8,8,8,3,3,3,8,8,8,8,8,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,8,8,8,8,8,3,3,3,8,8,8,8,8,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,8,8,8,8,8,3,3,3,8,8,8,8,8,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,8,8,8,8,8,3,3,3,8,8,8,8,8,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		};
		public override int[,] Furniture => new int[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0},
			{0,0,0,0,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,2,0,9,0,0,7,0,8,0,5,0,0,10,0,0,0,9,0,6,0,0,0,0},
			{0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		};

		private static int shingleColor;
		public override bool Generate()
		{
			shingleColor = WorldGen.genRand.NextBool() ? TileID.RedDynastyShingles : TileID.BlueDynastyShingles;
			bool placed = false;
			int attempts = 0;
			while (!placed && attempts++ < 100000)
			{
				// Select a place in the first 6th of the world, avoiding the oceans
				int towerX = WorldGen.genRand.Next(0, Main.maxTilesX); // from 50 since there's a unaccessible area at the world's borders
																			 // 50% of choosing the last 6th of the world
																			 // Choose which side of the world to be on randomly
				/*if (WorldGen.genRand.NextBool())
				{
					towerX = Main.maxTilesX - towerX;
				}*/

				//Start at 200 tiles above the surface instead of 0, to exclude floating islands
				int towerY = (int)Main.worldSurface - 200;

				// We go down until we hit a solid tile or go under the world's surface
				while (!WorldGen.SolidTile(towerX, towerY) && towerY <= Main.worldSurface)
				{
					towerY++;
				}

				// If we went under the world's surface, try again
				if (towerY > Main.worldSurface)
				{
					continue;
				}
				Tile tile = Main.tile[towerX, towerY];
				// If the type of the tile we are placing the tower on doesn't match what we want, try again
				if (!(tile.TileType == TileID.IceBlock
					|| tile.TileType == TileID.SnowBlock))
				{
					continue;
				}

				// Don't place the tower if the area isn't flat
				if (!YggdrasilWorld.CheckFlat(towerX, towerY, Tiles.GetLength(1), 3)) 
					continue;

				// place the tower
				Place(towerX, towerY);
				// extend the base a bit
				for (int i = towerX - 2; i < towerX + Tiles.GetLength(1) - 4; i++)
				{
					for (int k = towerY + 3; k < towerY + 9; k++) //12
					{
						WorldGen.PlaceTile(i, k, TileID.SnowBlock, mute: true, forced: true);
						WorldGen.SlopeTile(i, k);
					}
				}
			}
			//if (!placed) YggdrasilMod.Logger.Error("Worldgen: FAILED to place Goblin Tower, ground not flat enough?");
			return placed;
		}

		protected override TileData TileMap(int tile, int x, int y)
		{
			switch (tile)
			{
				case 1:
					return new TileData(TileID.GrayBrick);
				case 2:
					return new TileData(TileID.SnowBlock);
				case 3:
					return new TileData(TileID.BorealWood);
				case 4:
					return new TileData(TileID.WoodenBeam);
				case 5:
					return new TileData(TileID.StoneSlab);
				case 6:
					return new TileData(TileID.Cobweb);
			}
			return null;
		}

		protected override TileData FurnitureMap(int tile, int x, int y)
		{
			switch (tile)
			{
				case 4:
					return new ChestData(ModContent.TileType<VikingChestTile>(), style: 1);
				case 5:
					return new ObjectData(TileID.Fireplace);
				case 6:
					return new ObjectData(93); //Tiki Torch
				case 7:
					return new ObjectData(TileID.Tables);
				case 8:
					return new ObjectData(TileID.Chairs);
				case 9:
					return new TileData(TileID.ClosedDoor, 30);
				case 10:
					return new TileData(TileID.Pots);


			}
			return null;
		}

		protected override WallData WallMap(int wall, int x, int y)
		{
			switch (wall)
			{
				case 1:
					return new WallData(WallID.Wood);
				case 2:
					return new WallData(WallID.ArcaneRunes);
				case 3:
					return new WallData(WallID.GrayBrick);
				case 5:
					return new WallData(WallID.WoodenFence);
				case 8:
					return new WallData(WallID.Planked);
			}
			return new WallData(-1);
		}
	}
}