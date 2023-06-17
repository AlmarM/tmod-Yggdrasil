using Terraria.DataStructures;

namespace Yggdrasil.Utils;

public static class TileUtils
{
    public static Point16 GetTopLeftPoint(int i, int j, int tileX, int tileY)
    {
        return new Point16(i - tileX / 18, j - tileY / 18);
    }

    public static bool TryGetTileEntityAs<T>(int i, int j, out T entity) where T : TileEntity
    {
        if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out TileEntity tileEntity) &&
            tileEntity is T outputEntity)
        {
            entity = outputEntity;
            return true;
        }

        entity = null;
        return false;
    }
}