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
using Yggdrasil.Content.Tiles.IronWood;

namespace Yggdrasil.World
{

	public class YggdrasilWorld : ModSystem
	{
		
		public static bool IronWoodBiome = false;
		public static bool ZoneIronWood;
		public static int IronWoodTiles = 0;
		public static bool gennedVikingHouse = false;

		public override void OnWorldLoad()
		{
			ZoneIronWood = false;
			gennedVikingHouse = false;
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

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			IronWoodTiles = tileCounts[ModContent.TileType<IronWoodDirtTile>()] + tileCounts[ModContent.TileType<IronWoodGrassTile>()]
			+ tileCounts[ModContent.TileType<IronWoodStoneTile>()] + tileCounts[ModContent.TileType<IronWoodIceTile>()] + tileCounts[ModContent.TileType<IronWoodSandTile>()];
		}

        public override void PostUpdateEverything()
        {
			//if (ZoneIronWood)
			//Main.NewText(IronWoodTiles);
		}
	}	
}