using Terraria.DataStructures;

namespace Yggdrasil.Utils;

public static class TileUtils
{
    public static Point16 GetTopLeftPoint(int i, int j, int tileX, int tileY)
    {
        return new Point16(i - tileX / 18, j - tileY / 18);
    }

    // public static Point16 GetTileWorldCoord(int i, int j, int type)
    // {
    //     Point16 origin = GetTileOrigin(type);
    //
    //     Tile tile = Framing.GetTileSafely(i, j);
    //     var frame = new Point16(tile.TileFrameX / 18, tile.TileFrameY / 18);
    //
    //     Point16 offset = frame - origin;
    //
    //     return new Point16(i, j) - offset;
    // }
    //
    // public static Point16 GetTileOrigin(int type, int style = 0, int alternate = 0)
    // {
    //     return TileObjectData.GetTileData(type, style, alternate).Origin;
    // }
    //

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