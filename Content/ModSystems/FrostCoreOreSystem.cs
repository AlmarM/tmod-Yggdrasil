using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Yggdrasil.WorldGen;

namespace Yggdrasil.Content.ModSystems;

public class FrostCoreOreSystem : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
    {
        // Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

        // The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
        // First, we find out which step "Shinies" is.
        int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
        if (shiniesIndex != -1)
        {
            // Next, we insert our pass directly after the original "Shinies" pass.
            tasks.Insert(shiniesIndex + 1, new FrostCoreOrePass("Frost Core Ores", 237.4298f));
        }
    }
}