using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Content.Tiles.Furniture;
using Terraria.IO;
using Yggdrasil.Content.Tiles.Svartalvheim;

namespace Yggdrasil.World;

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

        ushort SvartDirt = (ushort)ModContent.TileType<SvartalvheimDirtTile>();
        ushort SvartGrass = (ushort)ModContent.TileType<SvartalvheimGrassTile>();
        ushort SvartStone = (ushort)ModContent.TileType<SvartalvheimStoneTile>();
        ushort SvartWallUnsafe = (ushort)ModContent.WallType<SvartalvheimWallTileUnsafe>();
        ushort SvartChest = (ushort)ModContent.TileType<VikingChestTile>();
        ushort SvartGlowingStone = (ushort)ModContent.TileType<SvartalvheimGlowingStoneTile>();
        ushort SvartBrickWall = (ushort)ModContent.WallType<SvartalvheimBrickWallTile>();
        ushort SvartBrick = (ushort)ModContent.TileType<SvartalvheimBrickTile>();

        //Used to genreate the zone
        Point point = new Point(originX, originY);

        //Generating zone area
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius),
            Actions.Chain(new Actions.ClearTile(true).Output(zoneShapeData)));

        //Adding Dirt and Grass
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius),
            Actions.Chain(new Actions.SetTile(SvartDirt), new Actions.SetFrames(true).Output(zoneShapeData)));
        //WorldUtils.Gen(point, new Shapes.Circle(zoneRadius), Actions.Chain(new Actions.SetTile(SvartGrass), new Actions.SetFrames(frameNeighbors: true)));

        //Adding little stones randomly everywhere
        WorldUtils.Gen(point, new Shapes.Circle(zoneRadius),
            Actions.Chain(new Modifiers.Dither(.9), new Actions.SetTile(SvartStone), new Actions.SetFrames(true)));

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
            if (tile.HasTile && tile.TileType == SvartDirt)
            {
                WorldGen.TileRunner(x, y, strength, steps, SvartStone);
            }
        }

        //Add a some water at the bottom
        Point pointWater = new Point(originX, originY + 50);
        WorldUtils.Gen(pointWater, new ModShapes.All(zoneShapeData), Actions.Chain(
            new Modifiers.RectangleMask(-100, 100, 0, 80), new Modifiers.IsEmpty(),
            new Actions.SetLiquid(1)));

        //Adding layer of stones in the outline shape
        zoneOutsideShapeData.Subtract(zoneShapeData, point, point);
        WorldUtils.Gen(point, new ModShapes.All(zoneOutsideShapeData), new Actions.SetTile(SvartStone, true));

        //Adding layer of broken-style stones outside the outline shape
        zoneMoreOutsideShapeData.Subtract(zoneShapeData, point, point);
        zoneMoreOutsideShapeData.Subtract(zoneOutsideShapeData, point, point);
        WorldUtils.Gen(point, new ModShapes.All(zoneMoreOutsideShapeData),
            Actions.Chain(new Modifiers.Dither(.7), new Actions.SetTile(SvartStone, true)));

        //Adding walls
        WorldUtils.Gen(point, new ModShapes.All(zoneShapeData), Actions.Chain(new Actions.PlaceWall(SvartWallUnsafe)));

        //Adding Cold Iron in there over dirt and stone
        for (int k = 0; k < 150; k++)
        {
            int ironX = WorldGen.genRand.Next(originX - 100, originX + 100);
            int ironY = WorldGen.genRand.Next(originY - 100, originY + 100);

            Tile tile = Framing.GetTileSafely(ironX, ironY);
            if (tile.HasTile && (tile.TileType == SvartStone || tile.TileType == SvartDirt))
            {
                WorldGen.TileRunner(ironX, ironY, WorldGen.genRand.Next(5, 7), WorldGen.genRand.Next(5, 10),
                    ModContent.TileType<ColdIronTile>());
                //WorldGen.SquareTileFrame(ironX, ironY, true);
            }
        }

        //Adding glowing bits on walls
        for (int k = 0; k < 100; k++)
        {
            int x = WorldGen.genRand.Next(originX - 150, originX + 150);
            int y = WorldGen.genRand.Next(originY - 150, originY + 150);

            Tile tile = Framing.GetTileSafely(x, y);
            if (!WorldGen.SolidTile(x, y) && tile.TileType != SvartBrickWall)
            {
                WorldGen.PlaceTile(x, y, SvartGlowingStone);
            }
        }

        Rectangle bounds = ShapeData.GetBounds(point, zoneShapeData, zoneOutsideShapeData, zoneMoreOutsideShapeData);
        WorldGen.structures.AddProtectedStructure(bounds, 2);

        TileID.Sets.GeneralPlacementTiles[SvartStone] = false;
        TileID.Sets.GeneralPlacementTiles[SvartBrick] = false;
    }
}