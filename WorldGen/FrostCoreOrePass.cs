using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Yggdrasil.Content.Tiles;

namespace Yggdrasil.WorldGen;

public class FrostCoreOrePass : GenPass
{
    public FrostCoreOrePass(string name, float loadWeight) : base(name, loadWeight)
    {
    }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
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
            int x = Terraria.WorldGen.genRand.Next(0, Main.maxTilesX);

            // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
            int y = Terraria.WorldGen.genRand.Next(Terraria.WorldGen.snowBG, Main.maxTilesY);

            // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
            // Feel free to experiment with strength and step to see the shape they generate.
            Tile tile = Framing.GetTileSafely(x, y);
            
            if (tile.HasTile && tile.TileType == TileID.IceBlock)
            {
                int strength = Terraria.WorldGen.genRand.Next(3, 8);
                int steps = Terraria.WorldGen.genRand.Next(10, 30);

                Terraria.WorldGen.TileRunner(x, y, strength, steps, ModContent.TileType<FrostCoreTile>());
            }
        }
    }
}