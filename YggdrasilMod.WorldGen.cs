 using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Terraria.IO;
using Yggdrasil.Tiles;
using Yggdrasil.Tiles.Furniture;
using Yggdrasil.Items.Others;
using Yggdrasil.Items.Accessories;


namespace YggdrasilWorld
{
	class YggdrasilWorldGen : ModSystem
	{
		//*************************************
		//Super Duper Debugging stuff there there
		//*************************************
		/*public static bool JustPressed(Keys key)
		{
			return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
		}
		
		public override void PostUpdateEverything()
		{
			if (JustPressed(Keys.D1))
			{
	
			}
            
		}*/
		//*************************************
		//Super Duper Debugging stuff there there
		//*************************************

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			int VikingChestIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Water Chests"));

			if (ShiniesIndex != -1)
			{
				// Next, we insert our pass directly after the original "Shinies" pass.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Frost Core Ores", FrostCoreGen));
			}

			if (VikingChestIndex != -1)
			{
				tasks.Insert(VikingChestIndex + 1, new PassLegacy("Viking Chest", VikingChestGen));
			}
		}

		private void FrostCoreGen(GenerationProgress progress, GameConfiguration configuration)
		{
			// progress.Message is the message shown to the user while the following code is running.
			// Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes.
			progress.Message = "Frost Core Ores";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.0005); k++)
			{
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);

				// WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
				int y = WorldGen.genRand.Next(0, Main.maxTilesY);

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
				// Feel free to experiment with strength and step to see the shape they generate.
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.HasTile && tile.TileType == TileID.IceBlock || tile.TileType == TileID.SnowBlock)
				{
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(10, 30), ModContent.TileType<FrostCoreTile>());
				}
			}
		}
		private void VikingChestGen(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Viking Chests";

			for (int i = 0; i < 10; i++)
			{
				bool success = false;
				int attempts = 0;
				while (!success)
				{
					attempts++;
					if (attempts > 1000)
					{
						break;
					}
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);//(int)Main.MouseWorld.X / 16;
					int y = WorldGen.genRand.Next(0, Main.maxTilesY);//(int)Main.MouseWorld.Y / 16;

					Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

					var point = new Point(x, y);
					Point resultPoint;
					bool searchSuccessful = WorldUtils.Find(point, Searches.Chain(new Searches.Down(20), new GenCondition[]
					{
						new Conditions.IsSolid().AreaAnd(2, 1),
						new Conditions.IsTile(TileID.IceBlock).AreaAnd(2, 1),
					}), out resultPoint);
					if (searchSuccessful)
					{
						//Main.NewText("GREAT");
						Dust.QuickBox(new Vector2(resultPoint.X, resultPoint.Y) * 16, new Vector2(resultPoint.X + 1, resultPoint.Y + 1) * 16, 2, Color.YellowGreen, null);
						int chestSpawn = WorldGen.PlaceChest(resultPoint.X, resultPoint.Y - 1, (ushort)ModContent.TileType<VikingChestTile>(), true, style: 1);
						success = chestSpawn != -1;
						
						int chestIndex = chestSpawn;

						if (chestIndex != -1)
						{
							Chest chest = Main.chest[chestIndex];
							// itemsToAdd will hold type and stack data for each item we want to add to the chest
							var itemsToAdd = new List<(int type, int stack)>();

							// Using a switch statement and a random choice to add sets of items.
							switch (Main.rand.Next(4))
							{
								case 0:
									itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
									break;
								case 1:
									itemsToAdd.Add((ModContent.ItemType<BerserkerRing>(), 1));
									break;
								case 2:
									itemsToAdd.Add((ModContent.ItemType<RunicSlab>(), 1));
									break;
								case 3:
									itemsToAdd.Add((ModContent.ItemType<RunicSlab>(), 1));
									itemsToAdd.Add((ModContent.ItemType<BerserkerRing>(), 1));
									itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
									break;
							}

							// Finally, iterate through itemsToAdd and actually create the Item instances and add to the chest.item array
							int chestItemIndex = 0;
							foreach (var itemToAdd in itemsToAdd)
							{
								Item item = new Item();
								item.SetDefaults(itemToAdd.type);
								item.stack = itemToAdd.stack;
								chest.item[chestItemIndex] = item;
								chestItemIndex++;
								if (chestItemIndex >= 40)
									break; // Make sure not to exceed the capacity of the chest
							}
						}
					}
				}
			}
		}
	}
}


