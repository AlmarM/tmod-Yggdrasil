using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Yggdrasil.CheeseMaking;
using Yggdrasil.CheeseMaking.Content.Items;
using Yggdrasil.CheeseMaking.Content.Tiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Assets.CheeseMaking.Content.TileEntities;

public class FermentingBarrelTileEntity : ModTileEntity
{
    private int _firstItemType = -1;
    private int _storedAmount;
    private int _storedTime;

    public bool IsFull => _storedAmount == 5;

    public bool IsDone => _storedTime >= TimeUtils.SecondsToTicks(10);

    public override bool IsTileValidForEntity(int x, int y)
    {
        Tile tile = Main.tile[x, y];
        return tile.HasTile && tile.TileType == ModContent.TileType<FermentingBarrelTile>();
    }

    public override int Hook_AfterPlacement(int i, int j, int tileType, int style, int direction, int alternate)
    {
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            NetMessage.SendTileSquare(Main.myPlayer, i, j, 2, 2);
            NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i, j, Type);
        }

        int id = Place(i, j);

        return id;
    }

    public override void OnNetPlace()
    {
        if (Main.netMode == NetmodeID.Server)
        {
            NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, ID, Position.X, Position.Y);
        }
    }

    public override void NetSend(BinaryWriter writer)
    {
        writer.Write(_firstItemType);
        writer.Write(_storedAmount);
        writer.Write(_storedTime);
    }

    public override void NetReceive(BinaryReader reader)
    {
        _firstItemType = reader.ReadInt32();
        _storedAmount = reader.ReadInt32();
        _storedTime = reader.ReadInt32();
    }

    public override void SaveData(TagCompound tag)
    {
        tag.Set("StoredItemType", _firstItemType);
        tag.Set("StoredAmount", _storedAmount);
        tag.Set("StoredTime", _storedTime);
    }

    public override void LoadData(TagCompound tag)
    {
        _firstItemType = tag.GetInt("StoredItemType");
        _storedAmount = tag.GetInt("StoredAmount");
        _storedTime = tag.GetInt("StoredTime");
    }

    public bool CanAddItem(int itemType)
    {
        return (_firstItemType == -1 || _firstItemType == itemType) && !IsFull;
    }

    public bool AddItem(int itemType)
    {
        if (!CanAddItem(itemType))
        {
            return false;
        }

        _firstItemType = itemType;
        _storedAmount++;

        if (IsFull)
        {
            var fermentingBarrelTile = ModContent.GetInstance<FermentingBarrelTile>();
            fermentingBarrelTile.SetState(Position.X, Position.Y, FermentingBarrelState.Closed);
        }

        return true;
    }

    public override void Update()
    {
        if (!IsFull && IsDone)
        {
            return;
        }

        _storedTime += (int)Main.dayRate;

        if (IsDone)
        {
            var fermentingBarrelTile = ModContent.GetInstance<FermentingBarrelTile>();
            fermentingBarrelTile.SetState(Position.X, Position.Y, FermentingBarrelState.Open);
        }
    }

    public bool RightClick()
    {
        if (IsDone)
        {
            var position = new Vector2(Position.X * 16, Position.Y * 16);

            for (var i = 0; i < 8; i++)
            {
                Item.NewItem(null, position, 32, 32, ModContent.ItemType<Curd>());
            }

            _firstItemType = -1;
            _storedAmount = 0;
            _storedTime = 0;

            return true;
        }

        return false;
    }

    public static bool Get(int i, int j, out FermentingBarrelTileEntity entity)
    {
        Tile tile = Main.tile[i, j];
        Point16 topLeft = TileUtils.GetTopLeftPoint(i, j, tile.TileFrameX, tile.TileFrameY);

        if (!TileUtils.TryGetTileEntityAs<FermentingBarrelTileEntity>(topLeft.X, topLeft.Y, out var foundEntity))
        {
            entity = null;
            return false;
        }

        entity = foundEntity;
        return true;
    }
}