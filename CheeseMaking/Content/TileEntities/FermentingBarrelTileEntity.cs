using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Yggdrasil.CheeseMaking;
using Yggdrasil.CheeseMaking.Content.Tiles;

namespace Yggdrasil.Assets.CheeseMaking.Content.TileEntities;

public class FermentingBarrelTileEntity : ModTileEntity
{
    private int _firstItemType = -1;
    private int _storedAmount;

    public bool IsFull => _storedAmount == 5;

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

        Main.NewText($"{i}, {j}");

        return id;
    }

    public override void OnNetPlace()
    {
        if (Main.netMode == NetmodeID.Server)
        {
            NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, ID, Position.X, Position.Y);
        }
    }

    public override void OnKill()
    {
        Main.NewText("killed");

        base.OnKill();
    }

    public override void NetSend(BinaryWriter writer)
    {
        Main.NewText("NetSend");

        base.NetSend(writer);
    }

    public override void NetReceive(BinaryReader reader)
    {
        Main.NewText("NetReceive");

        base.NetReceive(reader);
    }

    public override void SaveData(TagCompound tag)
    {
        tag.Set("StoredItemType", _firstItemType);
        tag.Set("StoredAmount", _storedAmount);
    }

    public override void LoadData(TagCompound tag)
    {
        _firstItemType = tag.GetInt("StoredItemType");
        _storedAmount = tag.GetInt("StoredAmount");
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
}