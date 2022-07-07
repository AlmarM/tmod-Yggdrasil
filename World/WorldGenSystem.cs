using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Content.Tiles.IronWood;

namespace Yggdrasil.World;

public class WorldGenSystem : ModSystem
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
            new VikingHouseGen().Generate();
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
        int shiniesIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Shinies"));
        int vikingChestIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Water Chests"));
        int vikingHouseIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Pyramids"));

        if (shiniesIndex != -1)
        {
            // Next, we insert our pass directly after the original "Shinies" pass.
            tasks.Insert(shiniesIndex + 1, new PassLegacy("Frostcore Ores", FrostCoreGen));
        }

        if (vikingChestIndex != -1)
        {
            tasks.Insert(vikingChestIndex + 1, new PassLegacy("Viking Chest", VikingChestGen));
        }

        if (vikingHouseIndex != -1)
        {
            tasks.Insert(vikingHouseIndex + 1, new PassLegacy("Viking House", VikingHouseGen));
        }
    }

    private void FrostCoreGen(GenerationProgress progress, GameConfiguration configuration)
    {
        // progress.Message is the message shown to the user while the following code is running.
        // Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes.
        progress.Message = "Frostcore Ores";

        // Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
        // "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
        for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.0005); k++)
        {
            // The inside of this for loop corresponds to one single splotch of our Ore.
            // First, we randomly choose any coordinate in the world by choosing a random x and y value.
            int x = WorldGen.genRand.Next(0, Main.maxTilesX);

            // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
            int y = WorldGen.genRand.Next(0, (int)((Main.rockLayer + Main.maxTilesY - 200)));

            // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
            // Feel free to experiment with strength and step to see the shape they generate.
            Tile tile = Framing.GetTileSafely(x, y);
            if (tile.HasTile && (tile.TileType == TileID.IceBlock || tile.TileType == TileID.SnowBlock))
            {
                int strength = WorldGen.genRand.Next(3, 8);
                int steps = WorldGen.genRand.Next(10, 30);

                WorldGen.TileRunner(x, y, strength, steps, ModContent.TileType<FrostCoreTile>());
            }
        }
    }

    private void VikingChestGen(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding Viking Chests.....";

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

                int x = WorldGen.genRand.Next(0, Main.maxTilesX); 
                int y = WorldGen.genRand.Next(0, (int)((Main.rockLayer + Main.maxTilesY - 200)));

                Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

                var point = new Point(x, y);
                Point resultPoint;
                bool searchSuccessful = WorldUtils.Find(point, Searches.Chain(new Searches.Down(20),
                    new GenCondition[]
                    {
                        new Conditions.IsSolid().AreaAnd(2, 1),
                        new Conditions.IsTile(TileID.IceBlock).AreaAnd(2, 1),
                    }), out resultPoint);
                if (searchSuccessful)
                {
                    
                    Dust.QuickBox(new Vector2(resultPoint.X, resultPoint.Y) * 16,
                        new Vector2(resultPoint.X + 1, resultPoint.Y + 1) * 16, 2, Color.YellowGreen, null);
                    int chestSpawn = WorldGen.PlaceChest(resultPoint.X, resultPoint.Y - 1,
                        (ushort)ModContent.TileType<VikingChestTile>(), true, style: 1);
                    success = chestSpawn != -1;

                }
            }
        }
    }
    private void VikingHouseGen(GenerationProgress progress, GameConfiguration configuration)
    {
        int attempts = 0;

        while (true)
        {
            attempts++;
            if (attempts > 20)
                break;

            progress.Message = "Adding Viking Houses...";
            new VikingHouseGen().Generate();
        }
    }

    /*public override void PostUpdateNPCs()
    {
        if (NPC.downedSlimeKing && !YggdrasilWorld.IronWoodBiome)
        {
            YggdrasilWorld.IronWoodBiome = true;
            SpawnIronWoodBiome();
        }
    }

    //Generation code of the new Iron Wood biome
    private void SpawnIronWoodBiome()
    {
        int firstX = WorldGen.genRand.Next(100, (Main.maxTilesX / 2) - 500);
        if (Main.dungeonX > Main.maxTilesX / 2) //rightside dungeon
            firstX = WorldGen.genRand.Next((Main.maxTilesX / 2) + 300, Main.maxTilesX - 500);

        int xAxis = firstX;
        int xAxisMid = xAxis + 70;
        int xAxisEdge = xAxis + 380;
        int yAxis = 0;

        int distanceFromCenter = 0;

        int[] Soils = { TileID.Dirt, TileID.Mud, TileID.ClayBlock, TileID.SnowBlock };
        int[] Grasses = { TileID.Grass, TileID.CorruptGrass, TileID.HallowedGrass, TileID.CrimsonGrass };
        int[] Ices = { TileID.IceBlock, TileID.CorruptIce, TileID.HallowedIce, TileID.FleshIce };
        int[] Stones = { TileID.Stone, TileID.Ebonstone, TileID.Pearlstone, TileID.Crimstone, TileID.GreenMoss, 
            TileID.BrownMoss, TileID.RedMoss, TileID.BlueMoss, TileID.PurpleMoss };
        int[] Sands = { TileID.Sand, TileID.Ebonsand, TileID.Pearlsand, TileID.Crimsand, TileID.HardenedSand };

        int[] Decors = { TileID.Plants, TileID.CorruptPlants, TileID.CorruptThorns, TileID.Vines, TileID.JungleVines, 
            TileID.HallowedPlants, TileID.HallowedPlants2, TileID.HallowedVines, TileID.Stalactite, TileID.SmallPiles, 
            TileID.LargePiles, TileID.LargePiles2, TileID.CrimsonPlants, TileID.CrimsonVines, TileID.FallenLog }; 

        int[] Walls = { WallID.Dirt, WallID.Grass, WallID.SnowWallUnsafe, WallID.DirtUnsafe, WallID.EbonstoneUnsafe, WallID.MudUnsafe, 
            WallID.PearlstoneBrickUnsafe, WallID.CaveUnsafe, WallID.Cave2Unsafe, WallID.Cave3Unsafe, WallID.Cave4Unsafe, WallID.Cave5Unsafe, 
            WallID.Cave6Unsafe, WallID.Cave7Unsafe, WallID.GrassUnsafe, WallID.FlowerUnsafe, WallID.CorruptGrassUnsafe, WallID.HallowedGrassUnsafe, 
            WallID.IceUnsafe, WallID.CrimsonGrassUnsafe, WallID.CrimstoneUnsafe, WallID.Cave8Unsafe, WallID.CorruptionUnsafe1, WallID.CorruptionUnsafe2, 
            WallID.CorruptionUnsafe3, WallID.CorruptionUnsafe4, WallID.CrimsonUnsafe1, WallID.CrimsonUnsafe2, WallID.CrimsonUnsafe3, WallID.CrimsonUnsafe4, 
            WallID.DirtUnsafe1, WallID.DirtUnsafe2, WallID.DirtUnsafe3, WallID.DirtUnsafe4, WallID.HallowUnsafe1, WallID.HallowUnsafe2, WallID.HallowUnsafe3, 
            WallID.HallowUnsafe4, WallID.RocksUnsafe1, WallID.RocksUnsafe2, WallID.RocksUnsafe3, WallID.RocksUnsafe4, WallID.LivingWoodUnsafe, 
            WallID.CaveWall, WallID.CaveWall2 };

        for (int y = 0; y < (Main.maxTilesY - 400) ; y++)
        {
            yAxis++;
            xAxis = firstX;
            for (int i = 0; i < 450; i++)
            {
                xAxis++;
                int nullRandom = Main.tile[xAxis, yAxis + 1] == null ? 50 : 1;

                if (xAxis < xAxisMid - 1)
                    distanceFromCenter = xAxisMid - xAxis;
                else if (xAxis > xAxisEdge + 1)
                    distanceFromCenter = xAxis - xAxisEdge;

                if (Grasses.Contains(Main.tile[xAxis, yAxis].TileType) && Main.rand.Next(distanceFromCenter) < 10)
                {
                    Main.tile[xAxis, yAxis].TileType = (ushort)ModContent.TileType<IronWoodGrassTile>();
                    WorldGen.SquareWallFrame(xAxis, yAxis, true);
                }
                if (Soils.Contains(Main.tile[xAxis, yAxis].TileType) && Main.rand.Next(distanceFromCenter) < 10)
                {
                    Main.tile[xAxis, yAxis].TileType = (ushort)ModContent.TileType<IronWoodDirtTile>();
                    WorldGen.SquareWallFrame(xAxis, yAxis, true);
                }
                else if (Ices.Contains(Main.tile[xAxis, yAxis].TileType) && Main.rand.Next(distanceFromCenter) < 10)
                    Main.tile[xAxis, yAxis].TileType = (ushort)ModContent.TileType<IronWoodIceTile>();
                else if (Stones.Contains(Main.tile[xAxis, yAxis].TileType) && Main.rand.Next(distanceFromCenter) < 10)
                    Main.tile[xAxis, yAxis].TileType = (ushort)ModContent.TileType<IronWoodStoneTile>();
                else if (Sands.Contains(Main.tile[xAxis, yAxis].TileType) && Main.rand.Next(distanceFromCenter) < 10)
                    Main.tile[xAxis, yAxis].TileType = (ushort)ModContent.TileType<IronWoodSandTile>();

                if (Walls.Contains(Main.tile[xAxis, yAxis].WallType) && Main.rand.Next(distanceFromCenter) < 10)
                    Main.tile[xAxis, yAxis].WallType = (ushort)ModContent.WallType<IronWoodWallTile>(); //Converts walls

                if (Decors.Contains(Main.tile[xAxis, yAxis].TileType) && Main.rand.NextBool(nullRandom) && Main.rand.Next(distanceFromCenter) < 18)
                    WorldGen.KillTile(xAxis, yAxis, false, false, false); //Removes decor

                if (Main.tile[xAxis, yAxis].TileType == ModContent.TileType<IronWoodStoneTile>() && yAxis > (int)((Main.rockLayer + Main.maxTilesY - 500) / 2f) && Main.rand.NextBool(150))
                    WorldGen.TileRunner(xAxis, yAxis, WorldGen.genRand.Next(5, 7), 1, ModContent.TileType<ColdIronTile>(), false, 0f, 0f, true, true); //Adds ore

            }
        }

        //YggdrasilWorld.IronWoodBiome = true;

        if (Main.netMode == NetmodeID.SinglePlayer)
            Main.NewText("The Iron Wood grows...", 174, 128, 79);
        //else if (Main.netMode == NetmodeID.Server)
        //{
        //    NetMessage.SendData(MessageID.WorldData);
        //    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Giants passed over the land..."), Color.Orange, -1); 
        //}
    }*/

}