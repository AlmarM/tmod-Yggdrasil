using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.World
{
    public class YggdrasilWorld : ModSystem
    {
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
}