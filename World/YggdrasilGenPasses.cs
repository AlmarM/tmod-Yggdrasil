using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Content.Tiles.Furniture;
using Terraria.IO;
using System.Numerics;
using Yggdrasil.Content.Tiles.Svartalvheim;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;
using Yggdrasil.Content.Tiles.Furniture.SvartalvheimFurniture;

namespace Yggdrasil.World
{
	public class YggdrasilGenPasses
	{
		private static int maxIceCave = 0;
		private static int maxSvartHome = 0;

		public static void MicroBiomePass(GenerationProgress progress, GameConfiguration configuration)
		{
			int LonghouseAttempts = 0;
			int MicroIceCaveAttempts = 0;
			maxIceCave = 0;

			while (true)
			{
				LonghouseAttempts++;
				if (LonghouseAttempts > 30 || YggdrasilWorld.gennedVikingHouse == true)
					break;

				progress.Message = "Adding abbandoned longhouse...";
				GenerateVikingHouse();
			}

			while (true)
			{
				MicroIceCaveAttempts++;
				if (MicroIceCaveAttempts > 30 || maxIceCave == 5)
					break;

				progress.Message = "Adding micro ice caves...";
				GenerateMicroIceRoom();
			}

		}

		public static void SvartalvheimMicroPass(GenerationProgress progress, GameConfiguration configuration)
		{
			int HouseAttempts = 0;
			maxSvartHome = 0;

			while (true)
			{
				HouseAttempts++;
				if (HouseAttempts > 10 || maxSvartHome >= 5)
					break;

				progress.Message = "Adding dwarven homes...";
				GenerateSvartalvheimHouses();
			}
		}

		public static int OffsetX = -3;
		public static int OffsetY = -16;

		private static void GenerateVikingHouse()
		{
			int[,] HouseTiles = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,9,9,9,9,9,9,9,9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,9,9,9,9,3,3,3,3,9,9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,9,9,9,9,3,3,3,3,3,3,9,9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,9,9,9,9,3,3,8,8,8,8,3,3,9,9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,9,9,9,9,3,3,8,8,8,8,8,8,3,3,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,9,9,9,9,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,9,9,9,9,3,3,8,8,8,8,8,8,8,8,8,8,3,2,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,9,9,9,9,3,3,8,8,8,8,8,8,8,8,8,8,2,2,2,2,0,9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,9,9,9,9,3,3,8,8,8,8,8,8,8,8,8,8,8,2,2,2,3,3,9,9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,9,9,9,9,3,3,8,8,8,8,8,8,8,8,8,8,8,2,2,2,2,2,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,0,0,0},
			{0,9,9,9,3,3,3,8,8,8,8,8,8,8,8,8,8,2,2,2,2,2,2,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,0,0},
			{0,8,8,8,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,0},
			{0,8,8,8,3,3,3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,9,9,9,0},
			{0,0,8,8,3,3,3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,3,3,3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,3,3,3,8,8,8,0},
			{0,0,8,8,3,3,3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,3,3,3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,3,3,3,8,8,8,0},
			{0,0,0,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,2,2,2,8,0,0,0},
			{0,0,0,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,2,2,2,2,2,0,0,0,0},
			{0,0,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,2,2,2,2,2,2,2,2,0,0,0},
			{0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2},
			{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,5,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{0,0,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,2,2,2,2,2,0},
			{0,0,0,2,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,2,2,5,5,2,5,2,2,2,2,2,2,2,2,2,2,0,0},
			{0,0,0,2,2,2,2,2,2,2,5,5,5,5,2,2,2,2,2,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0},
			{0,0,0,2,2,2,2,2,2,2,5,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0},
			{0,0,0,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0},
			{0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0}


			};
			int[,] HouseSlopes = new int[,]

			// 1 = \ top
			// 2 = / top
			// 3 = / bottom
			// 4 = \ bottom
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,4,0,1,2,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,2,0,0,0,0,3,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,2,0,0,0,0,3,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,2,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,2,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,2,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}

			};
			int[,] HouseWalls = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,1,1,5,5,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,1,1,1,5,5,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,1,1,1,1,5,5,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,1,1,1,1,1,5,5,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,1,1,1,1,1,1,5,5,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,1,1,1,1,1,1,1,5,5,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,1,1,1,1,1,1,1,1,5,5,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,1,1,1,1,1,1,1,1,5,5,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,1,1,1,1,1,1,1,1,1,1,1,1,5,5,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,5,1,1,1,1,1,1,1,1,1,5,5,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
			{0,0,0,0,5,1,1,1,1,1,1,1,1,1,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
			{0,0,0,0,5,1,1,1,1,1,1,1,1,1,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,0,0,0,0},
			{0,0,0,0,5,1,5,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,1,5,0,0,0,0},
			{0,0,0,0,5,3,5,3,3,3,3,3,3,3,5,5,3,3,3,3,3,3,3,5,3,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,3,5,0,0,0,0},
			{0,0,0,0,5,3,5,3,3,3,3,3,3,3,5,5,3,3,3,3,3,3,3,5,3,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,3,5,0,0,0,0},
			{0,0,0,0,5,3,5,3,3,3,3,3,3,3,5,5,3,3,3,3,3,3,3,5,3,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,3,5,0,0,0,0},
			{0,0,0,0,5,3,5,3,3,3,3,3,3,3,5,5,3,3,3,3,3,3,3,5,3,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,3,5,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}

			};
			int[,] HouseFurnitures = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,0},
			{0,0,0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,9,9,9,0},
			{0,0,0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,0},
			{0,0,0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,9,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,0,0,0,0,0,5,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2},
			{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,5,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{0,0,2,2,2,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,5,5,2,2,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,2,2,2,2,2,0},
			{0,0,0,2,2,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,5,5,5,2,2,2,2,2,2,2,2,5,5,2,5,2,2,2,2,2,2,2,2,2,2,0,0},
			{0,0,0,2,2,2,2,2,2,2,5,5,5,5,2,2,2,2,2,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0},
			{0,0,0,2,2,2,2,2,2,2,5,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0},
			{0,0,0,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0},
			{0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0}

			};


			bool housePlaced = false;
			int attempts = 0;
			while (!housePlaced && attempts++ < 10000)
			{
				int houseX = WorldGen.genRand.Next(0, Main.maxTilesX);
				int houseY = 0;

				//if (WorldGen.genRand.NextBool())
				//{
				//	houseX = Main.maxTilesX - houseX;
				//}

				// We go down until we hit a solid tile or go under the world's surface
				while (!WorldGen.SolidTile(houseX, houseY) && houseY <= Main.worldSurface)
				{
					houseY++;
				}

				// If we went under the world's surface, try again
				//if (houseY > Main.worldSurface)
				//{
				//	continue;
				//}

				Tile tile = Main.tile[houseX, houseY];
				// If the type of the tile we are placing the house on doesn't match what we want, try again
				if (tile.TileType != TileID.IceBlock && tile.TileType != TileID.SnowBlock)
				{
					continue;
				}


				// place the house
				VikingHousePlacement(houseX, houseY, HouseTiles, HouseWalls, HouseSlopes, HouseFurnitures);

				housePlaced = true;
				YggdrasilWorld.gennedVikingHouse = true;
			}
		}

		private static void VikingHousePlacement(int i, int j, int[,] Tiles, int[,] Walls, int[,] Slopes, int[,] Furnitures)
		{
			for (int y = 0; y < Tiles.GetLength(0); y++)
			{
				for (int x = 0; x < Tiles.GetLength(1); x++)
				{
					int k = x + i + OffsetX;
					int l = y + j + OffsetY;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Tiles[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 2:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 3:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 4:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 5:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 6:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 7:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 8:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 9:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
						}
					}
				}
			}

			for (int y = 0; y < Walls.GetLength(0); y++)
			{
				for (int x = 0; x < Walls.GetLength(1); x++)
				{
					int k = x + i + OffsetX;
					int l = y + j + OffsetY;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Walls[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 2:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 3:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 5:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 8:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
						}
					}
				}
			}

			for (int y = 0; y < Tiles.GetLength(0); y++)
			{
				for (int x = 0; x < Tiles.GetLength(1); x++)
				{
					int k = x + i + OffsetX;
					int l = y + j + OffsetY;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Tiles[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.PlaceTile(k, l, TileID.GrayBrick);
								WorldGen.SlopeTile(k, l, Slopes[y, x]);
								break;
							case 2:
								WorldGen.PlaceTile(k, l, TileID.SnowBlock);
								WorldGen.SlopeTile(k, l, Slopes[y, x]);
								break;
							case 3:
								WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<NordicWoodTile>());
								WorldGen.SlopeTile(k, l, Slopes[y, x]);
								break;
							case 4:
								WorldGen.PlaceTile(k, l, TileID.WoodenBeam);
								break;
							case 5:
								WorldGen.PlaceTile(k, l, TileID.IceBlock);
								break;
							case 6:
								WorldGen.PlaceTile(k, l, TileID.Cobweb);
								break;
							case 7:
								WorldGen.PlaceTile(k, l, TileID.Platforms);
								break;
							case 9:
								WorldGen.PlaceTile(k, l, TileID.HayBlock);
								WorldGen.SlopeTile(k, l, Slopes[y, x]);
								break;
						}
					}
				}
			}

			for (int y = 0; y < Walls.GetLength(0); y++)
			{
				for (int x = 0; x < Walls.GetLength(1); x++)
				{
					int k = x + i + OffsetX;
					int l = y + j + OffsetY;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Walls[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.PlaceWall(k, l, (ushort)ModContent.WallType<NordicWoodWallTile>());
								break;
							case 2:
								WorldGen.PlaceWall(k, l, WallID.Planked);
								break;
							case 3:
								WorldGen.PlaceWall(k, l, WallID.GrayBrick);
								break;
							case 5:
								WorldGen.PlaceWall(k, l, (ushort)ModContent.WallType<NordicWoodFenceWallTile>());
								break;
						}
					}
				}
			}

			for (int y = 0; y < Furnitures.GetLength(0); y++)
			{
				for (int x = 0; x < Furnitures.GetLength(1); x++)
				{
					int k = x + i + OffsetX;
					int l = y + j + OffsetY;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Furnitures[y, x])
						{
							case 0:
								break;
							case 4:
								WorldGen.PlaceChest(k, l, (ushort)ModContent.TileType<VikingChestTile>(), style: 1);
								break;
							case 5:
								WorldGen.PlaceObject(k, l, TileID.Fireplace, style: 1);
								break;
							case 6:
								WorldGen.PlaceObject(k, l, TileID.SharpeningStation);
								break;
							case 7:
								WorldGen.PlaceObject(k, l, (ushort)ModContent.TileType<NordicWoodTableTile>());
								break;
							case 8:
								WorldGen.PlaceObject(k, l, (ushort)ModContent.TileType<VikingStatueTile>());
								break;
							case 9:
								WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<NordicWoodDoorClosed>());
								break;
						}
					}
				}
			}
		}

		private static void GenerateMicroIceRoom()
		{

			int[,] IceRoomTiles = new int[,]
			{
			{0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,},
			{0,0,0,0,1,1,1,9,9,9,9,9,1,1,1,0,0,0,0,},
			{0,0,0,1,1,9,9,9,9,9,9,9,9,9,1,1,0,0,0,},
			{0,0,0,1,9,9,9,9,9,9,9,9,9,9,9,1,0,0,0,},
			{0,0,0,1,9,9,9,9,9,9,9,9,9,9,9,1,0,0,0,},
			{0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			{2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,},
			{0,2,2,2,0,0,2,2,2,2,0,0,0,0,2,2,2,0,0,},

			};

			int[,] IceRoomWalls = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,1,1,2,1,1,1,1,0,0,0,0,0,0,},
			{0,0,0,0,0,1,2,2,2,1,1,1,1,1,0,0,0,0,0,},
			{0,0,0,0,1,1,2,2,1,1,1,2,2,1,1,0,0,0,0,},
			{0,0,0,0,1,1,1,1,1,1,1,2,2,2,1,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},

			};

			int[,] IceRoomFurnitures = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,},
			{0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			{2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,},
			{0,2,2,2,0,0,2,2,2,2,0,0,0,0,2,2,2,0,0,},

			};


			bool cavePlaced = false;
			int attempts = 0;
			while (!cavePlaced && attempts++ < 1000)
			{
				int caveX = WorldGen.genRand.Next(0, Main.maxTilesX);
				int caveY = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);

				if (WorldGen.genRand.NextBool())
				{
					caveX = Main.maxTilesX - caveX;
				}

				Tile tile = Main.tile[caveX, caveY];
				// If the type of the tile we are placing the house on doesn't match what we want, try again
				if (tile.TileType != TileID.IceBlock && tile.TileType != TileID.SnowBlock)
				{
					continue;
				}

				// Don't place the house if the area isn't flat
				//if (!WorldGenSystem.CheckFlat(houseX, houseY, HouseTiles.GetLength(1), 3)) 
				//	continue;

				// place the house
				MicroIceRoomPlacement(caveX, caveY, IceRoomTiles, IceRoomWalls, IceRoomFurnitures);
				
				maxIceCave++;
				cavePlaced = true;
			}

		}

		private static void MicroIceRoomPlacement(int i, int j, int[,] Tiles, int[,] Walls, int[,] Furnitures)
        {
			for (int y = 0; y < Tiles.GetLength(0); y++)
			{
				for (int x = 0; x < Tiles.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Tiles[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 2:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 3:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 9:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
						}
					}
				}
			}

			for (int y = 0; y < Walls.GetLength(0); y++)
			{
				for (int x = 0; x < Walls.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Walls[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 2:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
						}
					}
				}
			}

			for (int y = 0; y < Tiles.GetLength(0); y++)
			{
				for (int x = 0; x < Tiles.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Tiles[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.PlaceTile(k, l, TileID.IceBrick);
								break;
							case 2:
								WorldGen.PlaceTile(k, l, TileID.SnowBlock);
								break;
							case 3:
								WorldGen.PlaceTile(k, l, TileID.IceBlock);
								break;
						}
					}
				}
			}

			for (int y = 0; y < Walls.GetLength(0); y++)
			{
				for (int x = 0; x < Walls.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Walls[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.PlaceWall(k, l, WallID.IceBrick);
								break;
							case 2:
								WorldGen.PlaceWall(k, l, WallID.SnowBrick);
								break;
						}
					}
				}
			}

			for (int y = 0; y < Furnitures.GetLength(0); y++)
			{
				for (int x = 0; x < Furnitures.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Furnitures[y, x])
						{
							case 0:
								break;
							case 4:
								WorldGen.PlaceChest(k, l, (ushort)ModContent.TileType<VikingChestTile>(), style: 1);
								break;
							case 5:
								WorldGen.PlaceObject(k, l, TileID.Torches, style: 9);
								break;
							case 6:
								WorldGen.PlaceObject(k, l, TileID.Pots);
								break;
						}
					}
				}
			}
		}

		private static void GenerateSvartalvheimHouses()
		{

			int[,] HouseTiles = new int[,]
			{
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
			{1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,},
			{1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,},
			{1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,},
			{1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,},
			{1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,},
			{1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,},
			{1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			{2,2,2,2,2,0,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			{0,2,2,2,0,0,0,2,2,2,2,2,0,0,0,2,2,0,0,}

			};

			int[,] HouseWalls = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,}

			};

			int[,] HouseFurnitures = new int[,]
			{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,5,0,0,0,0,0,0,0,0,0,5,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
			{0,0,0,0,0,0,0,0,6,0,0,0,0,4,0,0,0,0,0,},
			{1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			{2,2,2,2,2,0,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			{0,2,2,2,0,0,0,2,2,2,2,2,0,0,0,2,2,0,0,}

			};


			bool housePlaced = false;
			int attempts = 0;
			while (!housePlaced && attempts++ < 200)
			{
				int houseX = (Main.maxTilesX / 2) + Main.rand.Next(-100, 100);
				int houseY = (Main.maxTilesY / 2) + Main.rand.Next(-100, 10);

				Tile tile = Main.tile[houseX, houseY];
				// If the type of the tile we are placing the house on doesn't match what we want, try again
				if (!(tile.TileType == ModContent.TileType<SvartalvheimDirtTile>() || tile.TileType == ModContent.TileType<SvartalvheimStoneTile>()))
				{
					continue;
				}

				//Checking if there are bricks on the way meaning there's another house
				Point point = new Point(houseX, houseY);
				Ref<int> brickCont = new Ref<int>(0);
				WorldUtils.Gen(point, new Shapes.Rectangle(25, 15), Actions.Chain(new GenAction[]
				{
					new Actions.ContinueWrapper(Actions.Chain(new GenAction[]
					{
						new Modifiers.OnlyTiles((ushort)ModContent.TileType<SvartalvheimBrickTile>()),
						new Actions.Scanner(brickCont)
					})),
				}));

				//If there are more than 5 bricks, try again
				if (brickCont.Value >= 1)
				{
					continue;
				}

				// place the house
				SvartalvheimHousePlacement(houseX, houseY, HouseTiles, HouseWalls,HouseFurnitures);

				maxSvartHome++;
				housePlaced = true;
			}

		}

		private static void SvartalvheimHousePlacement(int i, int j, int[,] Tiles, int[,] Walls, int[,] Furnitures)
		{
			for (int y = 0; y < Tiles.GetLength(0); y++)
			{
				for (int x = 0; x < Tiles.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Tiles[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 2:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 3:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 9:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
						}
					}
				}
			}

			for (int y = 0; y < Walls.GetLength(0); y++)
			{
				for (int x = 0; x < Walls.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Walls[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
							case 2:
								WorldGen.KillWall(k, l);
								Framing.GetTileSafely(k, l).ClearTile();
								break;
						}
					}
				}
			}

			for (int y = 0; y < Tiles.GetLength(0); y++)
			{
				for (int x = 0; x < Tiles.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Tiles[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.PlaceTile(k, l, ModContent.TileType<SvartalvheimBrickTile>());
								break;
							case 2:
								WorldGen.PlaceTile(k, l, ModContent.TileType<SvartalvheimStoneTile>());
								break;
							case 3:
								WorldGen.PlaceTile(k, l, TileID.IceBlock);
								break;
						}
					}
				}
			}

			for (int y = 0; y < Walls.GetLength(0); y++)
			{
				for (int x = 0; x < Walls.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Walls[y, x])
						{
							case 0:
								break;
							case 1:
								WorldGen.PlaceWall(k, l, ModContent.WallType<SvartalvheimBrickWallTile>());
								break;
							case 2:
								WorldGen.PlaceWall(k, l, WallID.SnowBrick);
								break;
						}
					}
				}
			}

			for (int y = 0; y < Furnitures.GetLength(0); y++)
			{
				for (int x = 0; x < Furnitures.GetLength(1); x++)
				{
					int k = x + i;
					int l = y + j;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (Furnitures[y, x])
						{
							case 0:
								break;
							case 4:
								if (YggdrasilWorld.SvartalvheimChests <= 2)
								{
									WorldGen.PlaceChest(k, l, (ushort)ModContent.TileType<SvartalvheimChestTile>(), style: 1);
									YggdrasilWorld.SvartalvheimChests++;
								}
								break;
							case 5:
								if (WorldGen.genRand.NextBool())
								{
									WorldGen.PlaceObject(k, l, TileID.Torches, style: 2);
								}
								break;
							case 6:
								if (WorldGen.genRand.NextBool())
								{
									WorldGen.PlaceObject(k, l, (ushort)ModContent.TileType<DvergrForgeTile>());
								}
								WorldGen.PlaceObject(k, l, TileID.SharpeningStation);
								break;
						}
					}
				}
			}
		}
	}
}
	