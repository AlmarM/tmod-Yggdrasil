using Terraria.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Armor;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Content.UI;

namespace Yggdrasil.World
{
	public class YggdrasilWorld : ModSystem
	{
		//Check if an area is flat enough to spawn the viking houses
		public static bool CheckFlat(int startX, int startY, int width, float threshold, int goingDownWeight = 0, int goingUpWeight = 0)
		{
			// Fail if the tile at the other end of the check plane isn't also solid
			if (!WorldGen.SolidTile(startX + width, startY)) return false;

			float totalVariance = 0;
			for (int i = 0; i < width; i++)
			{
				if (startX + i >= Main.maxTilesX) return false;

				// Fail if there is a tile very closely above the check area
				for (int k = startY - 1; k > startY - 100; k--)
				{
					if (WorldGen.SolidTile(startX + i, k)) return false;
				}

				// If the tile is solid, go up until we find air
				// If the tile is not, go down until we find a floor
				int offset = 0;
				bool goingUp = WorldGen.SolidTile(startX + i, startY);
				offset += goingUp ? goingUpWeight : goingDownWeight;
				while ((goingUp && WorldGen.SolidTile(startX + i, startY - offset))
					|| (!goingUp && !WorldGen.SolidTile(startX + i, startY + offset)))
				{
					offset++;
				}
				if (goingUp) offset--; // account for going up counting the first tile
				totalVariance += offset;
			}
			return totalVariance / width <= threshold;
		}

		public override void PostWorldGen()
		{
			//Adding item to viking chests
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				
				if (chest != null && Main.tile[chest.x, chest.y].TileType == (ushort)ModContent.TileType<VikingChestTile>())
				{
					var itemsToAdd = new List<(int type, int stack)>();

					// Using a switch statement and a random choice to add sets of items.
					switch (Main.rand.Next(4))
					{
						case 0:
							itemsToAdd.Add((ModContent.ItemType<RunicPotion>(), Main.rand.Next(1, 2)));
							itemsToAdd.Add((ModContent.ItemType<FrostCoreBar>(), Main.rand.Next(1, 3)));
							itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
							itemsToAdd.Add((ItemID.GoldCoin, Main.rand.Next(1, 2)));
							itemsToAdd.Add((ItemID.HealingPotion, Main.rand.Next(1, 2)));
							itemsToAdd.Add((ItemID.MiningPotion, Main.rand.Next(1, 2)));
							break;
						case 1:
							itemsToAdd.Add((ModContent.ItemType<RunicSlab>(), 1));
							itemsToAdd.Add((ModContent.ItemType<ArmRing>(), 1));
							itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
							itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(15, 35)));
							itemsToAdd.Add((ItemID.ClimbingClaws, 1));
							itemsToAdd.Add((ItemID.RegenerationPotion, Main.rand.Next(1, 2)));
							break;
						case 2:
							itemsToAdd.Add((ModContent.ItemType<VikingLeatherShirt>(), 1));
							itemsToAdd.Add((ModContent.ItemType<WoodArmRing>(), 1));
							itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
							itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(9, 18)));
							itemsToAdd.Add((ItemID.IceMirror, 1));
							itemsToAdd.Add((ItemID.ShoeSpikes, 1));
							itemsToAdd.Add((ItemID.SwiftnessPotion, Main.rand.Next(1, 2)));
							break;
						case 3:
							itemsToAdd.Add((ModContent.ItemType<NorsemanShield>(), 1));
							itemsToAdd.Add((ModContent.ItemType<StoneBlock>(), 1));
							itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
							itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(12, 31)));
							itemsToAdd.Add((ItemID.FlurryBoots, 1));
							itemsToAdd.Add((ItemID.RecallPotion, Main.rand.Next(2, 4)));
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