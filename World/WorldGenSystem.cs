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
        int MicroBiomeIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Life Crystals"));
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
            tasks.Insert(SvartalvheimIndex + 1, new PassLegacy("Svartalvheim", SvartalvheimGen.SvartalvheimGenPass));
        }

        if (SvartalvheimHouseIndex != -1)
        {
            tasks.Insert(SvartalvheimHouseIndex + 1,
                new PassLegacy("Svartalvheim House", YggdrasilGenPasses.SvartalvheimMicroPass));
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
}