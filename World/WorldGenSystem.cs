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
using Yggdrasil.Content.Tiles.Svartalvheim;

namespace Yggdrasil.World;

public class WorldGenSystem : ModSystem
{
    /*public static bool JustPressed(Keys key)
    {
        return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
    }

    public override void PostUpdateWorld()
    {
        if (JustPressed(Keys.D1))
        {

        }
    }*/


    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
    {
        // Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

        // The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
        // First, we find out which step "Shinies" is.
        int shiniesIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Shinies"));
        int MicroBiomeIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Lakes"));
        int SvartalvheimIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Dungeon"));
        int SvartalvheimHouseIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Micro Biomes"));

        if (shiniesIndex != -1)
        {
            tasks.Insert(shiniesIndex + 1, new PassLegacy("Frostcore Ores", FrostCoreGen));
        }

        if (MicroBiomeIndex != -1)
        {
            tasks.Insert(MicroBiomeIndex + 1, new PassLegacy("Micro Biome", YggdrasilGenPasses.MicroBiomePass));
        }

        if (SvartalvheimIndex != -1)
        {
            tasks.Insert(SvartalvheimIndex + 1, new PassLegacy("Svartalvheim", SvartalvheimGen));
        }

        if (SvartalvheimHouseIndex != -1)
        {
            tasks.Insert(SvartalvheimHouseIndex + 1, new PassLegacy("Svartalvheim House", YggdrasilGenPasses.SvartalvheimMicroPass));
        }

    }

    private void FrostCoreGen(GenerationProgress progress, GameConfiguration configuration)
    {
        
        progress.Message = "Frostcore Ores";

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

    private void SvartalvheimGen(GenerationProgress progress, GameConfiguration configuration)
    {
        Main.NewText("Dwarves diggy diggy hole...", 200, 94, 94);

            StructureMap SvartalvheimBiome = new StructureMap();

            int SvartX = (Main.maxTilesX / 2);
            int SvartY = (Main.maxTilesY / 2);
            int zoneRadius = 150;

            ShapeData zoneShapeData = new ShapeData();
            ShapeData zoneOutsideShapeData = new ShapeData();
            ShapeData zoneMoreOutsideShapeData = new ShapeData();

            Point point = new Point(SvartX, SvartY); //Used to genreate the zone

            //Generating zone area
            WorldUtils.Gen(point, new Shapes.Circle(zoneRadius), Actions.Chain(new Actions.ClearTile(frameNeighbors: true).Output(zoneShapeData)));
            WorldUtils.Gen(point, new Shapes.Circle(zoneRadius), Actions.Chain(new Actions.SetTile((ushort)ModContent.TileType<SvartalvheimDirtTile>()), new Actions.SetFrames(frameNeighbors: true).Output(zoneShapeData)));
            WorldUtils.Gen(point, new Shapes.Circle(zoneRadius), Actions.Chain(new Modifiers.Dither(.9), new Actions.SetTile((ushort)ModContent.TileType<SvartalvheimStoneTile>()), new Actions.SetFrames(frameNeighbors: true)));

            //Creating the outline shapes
            WorldUtils.Gen(point, new Shapes.Circle(zoneRadius + 5), new Actions.Blank().Output(zoneOutsideShapeData)); //This one is for a layer of stones all around the area
            WorldUtils.Gen(point, new Shapes.Circle(zoneRadius + 15), new Actions.Blank().Output(zoneMoreOutsideShapeData)); //This one is for a layer of broken-style stones outside the previous area

            //Digging tunnel through dirt
            for (int i = 0; i < 50; i++)
            {
                WorldGen.digTunnel(SvartX + Main.rand.NextFloat(-100, 100), SvartY + Main.rand.NextFloat(-100, 100), Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-0.01f, 0.01f), Main.rand.Next(50, 150), Main.rand.Next(2, 8), false);

            }

            //Adding stone through that dirt
            for (int i = 0; i < 150; i++)
            {
                int x = WorldGen.genRand.Next(SvartX - 150, SvartX + 150);
                int y = WorldGen.genRand.Next(SvartY - 150, SvartY + 150);
                int strength = WorldGen.genRand.Next(5, 30);
                int steps = WorldGen.genRand.Next(8, 15);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && tile.TileType == ModContent.TileType<SvartalvheimDirtTile>())
                {
                    WorldGen.TileRunner(x, y, strength, steps, ModContent.TileType<SvartalvheimStoneTile>());
                }
            }

            //Adding layer of stones in the outline shape
            zoneOutsideShapeData.Subtract(zoneShapeData, point, point);
            WorldUtils.Gen(point, new ModShapes.All(zoneOutsideShapeData), new Actions.SetTile((ushort)ModContent.TileType<SvartalvheimStoneTile>(), true));
            
            //Adding layer of broken-style stones outside the outline shape
            zoneMoreOutsideShapeData.Subtract(zoneShapeData, point, point);
            zoneMoreOutsideShapeData.Subtract(zoneOutsideShapeData, point, point);
            WorldUtils.Gen(point, new ModShapes.All(zoneMoreOutsideShapeData), Actions.Chain(new Modifiers.Dither(.7), new Actions.SetTile((ushort)ModContent.TileType<SvartalvheimStoneTile>(), true)));

            //Adding walls
            WorldUtils.Gen(point, new ModShapes.All(zoneShapeData), Actions.Chain(new Actions.PlaceWall((ushort)ModContent.WallType<SvartalvheimWallTileUnsafe>())));

            //Adding Cold Iron in there over dirt and stone
            for (int k = 0; k < 150; k++)
            {
                int ironX = WorldGen.genRand.Next(SvartX - 100, SvartX + 100);
                int ironY = WorldGen.genRand.Next(SvartY - 100, SvartY + 100);

                Tile tile = Framing.GetTileSafely(ironX, ironY);
                if (tile.HasTile && (tile.TileType == ModContent.TileType<SvartalvheimStoneTile>() || tile.TileType == ModContent.TileType<SvartalvheimDirtTile>()))
                {
                    WorldGen.TileRunner(ironX, ironY, WorldGen.genRand.Next(5, 7), WorldGen.genRand.Next(5, 10), ModContent.TileType<ColdIronTile>());
                    //WorldGen.SquareTileFrame(ironX, ironY, true);
                }
            }

            //Doesn't seem to work, the values are probably wrong
            //SvartalvheimBiome.AddStructure(new Rectangle(SvartX, SvartY, 300, 300));
    }


    //Check if an area is flat enough to spawn structures
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
}