using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Armor;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Terraria.ModLoader.IO;
using System.IO;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Tiles.Svartalvheim;
using Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;
using Yggdrasil.Content.Items.Weapons.Summon;
using Yggdrasil.Content.Items.Tools;
using Yggdrasil.Content.Tiles.Furniture.SvartalvheimFurniture;
using Yggdrasil.Runemaster.Content.Items.Accessories;
using Yggdrasil.Runemaster.Content.Items.Armors;

namespace Yggdrasil.World;

public class YggdrasilWorld : ModSystem
{
    public static bool IronWoodBiome = false;
    public static bool ColdIronGenerated;
    public static bool SvartalvheimGenerated;
    public static bool gennedVikingHouse = false;
    public static bool downedVikingInvasion;


    public static int SvartalvheimTiles = 0;
    public static int SvartalvheimChests = 0;

    private int casenumber = 0;

    public override void OnWorldLoad()
    {
        gennedVikingHouse = false;
        downedVikingInvasion = false;
        ColdIronGenerated = false;
        SvartalvheimGenerated = false;
        SvartalvheimChests = 0;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        downedVikingInvasion = tag.GetBool("downedVikingInvasion");
        ColdIronGenerated = tag.GetBool("ColdIronGenerated");
        SvartalvheimGenerated = tag.GetBool("SvartalvheimGenerated");
    }

    public override void SaveWorldData(TagCompound tag)
    {
        tag["downedVikingInvasion"] = downedVikingInvasion;
        tag["ColdIronGenerated"] = ColdIronGenerated;
        tag["SvartalvheimGenerated"] = SvartalvheimGenerated;
    }

    public override void NetSend(BinaryWriter writer)
    {
        var flags = new BitsByte();
        flags[0] = downedVikingInvasion;
    }

    public override void NetReceive(BinaryReader reader)
    {
        BitsByte flags = reader.ReadByte();
        downedVikingInvasion = flags[0];
    }

    public override void PostWorldGen()
    {
        //Adding item to chests
        for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
        {
            Chest chest = Main.chest[chestIndex];

            //Viking Chests
            if (chest != null && Main.tile[chest.x, chest.y].TileType ==
                (ushort)ModContent.TileType<VikingChestTile>())
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
                        itemsToAdd.Add((ItemID.Torch, Main.rand.Next(1, 3)));
                        itemsToAdd.Add((ItemID.WoodenArrow, Main.rand.Next(20, 35)));
                        break;
                    case 1:
                        itemsToAdd.Add((ModContent.ItemType<RunicSlab>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<ArmRing>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
                        itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(15, 35)));
                        itemsToAdd.Add((ItemID.ClimbingClaws, 1));
                        itemsToAdd.Add((ItemID.RegenerationPotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.Torch, Main.rand.Next(1, 3)));
                        itemsToAdd.Add((ItemID.WoodenArrow, Main.rand.Next(20, 35)));
                        break;
                    case 2:
                        itemsToAdd.Add((ModContent.ItemType<VikingLeatherShirt>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<WoodArmRing>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
                        itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(9, 18)));
                        itemsToAdd.Add((ItemID.IceMirror, 1));
                        itemsToAdd.Add((ItemID.ShoeSpikes, 1));
                        itemsToAdd.Add((ItemID.SwiftnessPotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.Torch, Main.rand.Next(1, 3)));
                        itemsToAdd.Add((ItemID.WoodenArrow, Main.rand.Next(20, 35)));
                        break;
                    case 3:
                        itemsToAdd.Add((ModContent.ItemType<DwarvenMedallion>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<StoneBlock>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<Linnen>(), Main.rand.Next(9, 15)));
                        itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(12, 31)));
                        itemsToAdd.Add((ItemID.FlurryBoots, 1));
                        itemsToAdd.Add((ItemID.RecallPotion, Main.rand.Next(2, 4)));
                        itemsToAdd.Add((ItemID.Torch, Main.rand.Next(1, 3)));
                        itemsToAdd.Add((ItemID.WoodenArrow, Main.rand.Next(20, 35)));
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

            //Svatalvheim Chests
            if (chest != null && Main.tile[chest.x, chest.y].TileType ==
                (ushort)ModContent.TileType<SvartalvheimChestTile>())
            {
                var itemsToAdd = new List<(int type, int stack)>();

                switch (casenumber)
                {
                    case 0:
                        itemsToAdd.Add((ModContent.ItemType<SvartalvheimMedallion>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<ColdIronBar>(), Main.rand.Next(2, 4)));
                        itemsToAdd.Add((ItemID.Dynamite, Main.rand.Next(2, 4)));
                        itemsToAdd.Add((ItemID.SpelunkerPotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.ShinePotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.Torch, Main.rand.Next(1, 5)));
                        itemsToAdd.Add((ItemID.GoldCoin, Main.rand.Next(2, 6)));
                        casenumber++;
                        break;
                    case 1:
                        itemsToAdd.Add((ModContent.ItemType<ThaneHamstaff>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<ColdIronBar>(), Main.rand.Next(2, 4)));
                        itemsToAdd.Add((ItemID.StickyBomb, Main.rand.Next(5, 7)));
                        itemsToAdd.Add((ItemID.ObsidianSkinPotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.LifeforcePotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.Torch, Main.rand.Next(1, 5)));
                        itemsToAdd.Add((ItemID.GoldCoin, Main.rand.Next(1, 4)));
                        casenumber++;
                        break;
                    case 2:
                        itemsToAdd.Add((ModContent.ItemType<DvergrHook>(), 1));
                        itemsToAdd.Add((ModContent.ItemType<ColdIronBar>(), Main.rand.Next(1, 5)));
                        itemsToAdd.Add((ModContent.ItemType<MoldyCheese>(), 1));
                        itemsToAdd.Add((ItemID.PotionOfReturn, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.RagePotion, Main.rand.Next(1, 2)));
                        itemsToAdd.Add((ItemID.StickyGlowstick, Main.rand.Next(3, 7)));
                        itemsToAdd.Add((ItemID.GoldCoin, Main.rand.Next(2, 3)));
                        casenumber = 0;
                        break;
                }


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
        SvartalvheimTiles = tileCounts[ModContent.TileType<SvartalvheimDirtTile>()] +
                            tileCounts[ModContent.TileType<SvartalvheimBrickTile>()]
                            + tileCounts[ModContent.TileType<SvartalvheimStoneTile>()];
    }

    public override void PostUpdateEverything()
    {
        //Main.NewText("In Svartalvheim");
    }
}