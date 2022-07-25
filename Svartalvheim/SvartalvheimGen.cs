using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Content.Tiles.Svartalvheim;

namespace Yggdrasil.Svartalvheim;

public class SvartalvheimGen
{
    public static void SvartalvheimGenPass(GenerationProgress progress, GameConfiguration configuration)
    {
        Main.NewText("Dwarves diggy diggy hole...", 200, 94, 94);

        int originX = Main.maxTilesX / 2;
        int originY = Main.maxTilesY / 2;
        int zoneRadius = 150;

        ShapeData zoneShapeData = new ShapeData();
        ShapeData zoneOutsideShapeData = new ShapeData();
        ShapeData zoneMoreOutsideShapeData = new ShapeData();
        ShapeData zoneHoleData = new ShapeData();

        ushort svartDirt = (ushort)ModContent.TileType<SvartalvheimDirtTile>();
        ushort svartGrass = (ushort)ModContent.TileType<SvartalvheimGrassTile>();
        ushort svartStone = (ushort)ModContent.TileType<SvartalvheimStoneTile>();
        ushort svartWallUnsafe = (ushort)ModContent.WallType<SvartalvheimWallTileUnsafe>();
        ushort svartChest = (ushort)ModContent.TileType<VikingChestTile>();
        ushort svartGlowingStone = (ushort)ModContent.TileType<SvartalvheimGlowingStoneTile>();
        ushort svartBrickWall = (ushort)ModContent.WallType<SvartalvheimBrickWallTile>();
        ushort svartBrick = (ushort)ModContent.TileType<SvartalvheimBrickTile>();

        //Used to genreate the zone
        Point point = new Point(originX, originY);

        //Generating zone area
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius),
            Actions.Chain(new Actions.ClearTile(true).Output(zoneShapeData)));

        //Adding Dirt and Grass
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius),
            Actions.Chain(new Actions.SetTile(svartDirt), new Actions.SetFrames(true).Output(zoneShapeData)));
        //WorldUtils.Gen(point, new Shapes.Circle(zoneRadius), Actions.Chain(new Actions.SetTile(SvartGrass), new Actions.SetFrames(frameNeighbors: true)));

        //Adding little stones randomly everywhere
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius),
            Actions.Chain(new Modifiers.Dither(.9), new Actions.SetTile(svartStone), new Actions.SetFrames(true)));

        //Creating the outline shapes
        //This one is for a layer of stones all around the area
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius + 5), new Actions.Blank().Output(zoneOutsideShapeData));

        //This one is for a layer of broken-style stones outside the previous area
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius + 15), new Actions.Blank().Output(zoneMoreOutsideShapeData));

        //Digging tunnel through dirt
        for (int i = 0; i < 50; i++)
        {
            WorldGen.digTunnel(originX + Main.rand.NextFloat(-100, 100), originY + Main.rand.NextFloat(-100, 100),
                Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-0.01f, 0.01f), Main.rand.Next(50, 150),
                Main.rand.Next(2, 8), false);
        }

        //Adding stone through that dirt
        for (int i = 0; i < 150; i++)
        {
            int x = WorldGen.genRand.Next(originX - 150, originX + 150);
            int y = WorldGen.genRand.Next(originY - 150, originY + 150);
            int strength = WorldGen.genRand.Next(5, 30);
            int steps = WorldGen.genRand.Next(8, 15);

            Tile tile = Framing.GetTileSafely(x, y);
            if (tile.HasTile && tile.TileType == svartDirt)
            {
                WorldGen.TileRunner(x, y, strength, steps, svartStone);
            }
        }

        //Add a some water at the bottom
        Point pointWater = new Point(originX, originY + 50);
        WorldUtils.Gen(pointWater, new ModShapes.All(zoneShapeData), Actions.Chain(
            new Modifiers.RectangleMask(-100, 100, 0, 80), new Modifiers.IsEmpty(),
            new Actions.SetLiquid(1)));

        //Adding layer of stones in the outline shape
        zoneOutsideShapeData.Subtract(zoneShapeData, point, point);
        WorldUtils.Gen(point, new ModShapes.All(zoneOutsideShapeData), new Actions.SetTile(svartStone, true));

        //Adding layer of broken-style stones outside the outline shape
        zoneMoreOutsideShapeData.Subtract(zoneShapeData, point, point);
        zoneMoreOutsideShapeData.Subtract(zoneOutsideShapeData, point, point);
        WorldUtils.Gen(point, new ModShapes.All(zoneMoreOutsideShapeData),
            Actions.Chain(new Modifiers.Dither(.7), new Actions.SetTile(svartStone, true)));

        //Adding walls
        WorldUtils.Gen(point, new ModShapes.All(zoneShapeData), Actions.Chain(new Actions.PlaceWall(svartWallUnsafe)));

        //Adding Cold Iron in there over dirt and stone
        for (int k = 0; k < 150; k++)
        {
            int ironX = WorldGen.genRand.Next(originX - 100, originX + 100);
            int ironY = WorldGen.genRand.Next(originY - 100, originY + 100);

            Tile tile = Framing.GetTileSafely(ironX, ironY);
            if (tile.HasTile && (tile.TileType == svartStone || tile.TileType == svartDirt))
            {
                int strength = WorldGen.genRand.Next(5, 7);
                int steps = WorldGen.genRand.Next(5, 10);

                WorldGen.TileRunner(ironX, ironY, strength, steps, ModContent.TileType<ColdIronTile>());

                //WorldGen.SquareTileFrame(ironX, ironY, true);
            }
        }

        //Adding glowing bits on walls
        for (int k = 0; k < 100; k++)
        {
            int x = WorldGen.genRand.Next(originX - 150, originX + 150);
            int y = WorldGen.genRand.Next(originY - 150, originY + 150);

            Tile tile = Framing.GetTileSafely(x, y);
            if (!WorldGen.SolidTile(x, y) && tile.TileType != svartBrickWall)
            {
                WorldGen.PlaceTile(x, y, svartGlowingStone);
            }
        }

        Rectangle bounds = ShapeData.GetBounds(point, zoneShapeData, zoneOutsideShapeData, zoneMoreOutsideShapeData);
        WorldGen.structures.AddProtectedStructure(bounds, 2);

        TileID.Sets.GeneralPlacementTiles[svartStone] = false;
        TileID.Sets.GeneralPlacementTiles[svartBrick] = false;
    }
}