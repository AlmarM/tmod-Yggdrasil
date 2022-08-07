using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Assets.CheeseMaking.Content.TileEntities;
using Yggdrasil.CheeseMaking.Content.Items;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Utils;

namespace Yggdrasil.CheeseMaking.Content.Tiles;

public class FermentingBarrelTile : YggdrasilTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;

        TileID.Sets.IgnoredByNpcStepUp[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };

        var tileEntity = ModContent.GetInstance<FermentingBarrelTileEntity>();
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(tileEntity.Hook_AfterPlacement, -1, 0, true);

        TileObjectData.addTile(Type);

        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Fermenting Barrel");
        AddMapEntry(new Color(200, 200, 200), name);
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        ModContent.GetInstance<FermentingBarrelTileEntity>().Kill(i, j);
    }

    public override void MouseOver(int i, int j)
    {
        Player localPlayer = Main.LocalPlayer;
        int heldItemType = localPlayer.HeldItem.type;

        if (!IsAcceptedItem(heldItemType))
        {
            return;
        }

        localPlayer.cursorItemIconEnabled = true;
        localPlayer.cursorItemIconID = heldItemType;

        if (!Main.mouseLeft || localPlayer.itemAnimation != 1)
        {
            return;
        }

        Tile tile = Main.tile[i, j];
        Point16 topLeft = TileUtils.GetTopLeftPoint(i, j, tile.TileFrameX, tile.TileFrameY);

        Main.NewText(topLeft);

        if (!TileUtils.TryGetTileEntityAs<FermentingBarrelTileEntity>(topLeft.X, topLeft.Y, out var entity))
        {
            return;
        }

        if (entity.AddItem(heldItemType))
        {
            localPlayer.HeldItem.stack--;
        }

        Main.NewText(Main.time);
    }

    public bool IsAcceptedItem(int itemType)
    {
        return itemType == ModContent.ItemType<MilkBucket>();
    }

    public FermentingBarrelState GetState(int i, int j)
    {
        Tile tile = Main.tile[i, j];

        return (FermentingBarrelState)(tile.TileFrameX / 36);
    }

    public void SetState(int i, int j, FermentingBarrelState state)
    {
        if (!Enum.IsDefined(typeof(FermentingBarrelState), state))
        {
            return;
        }

        var stateIntegral = (int)state + 1;
        var baseX = (short)(stateIntegral * 18);
        var rightX = (short)(baseX + 18);

        Main.tile[i, j].TileFrameX = baseX;
        Main.tile[i + 1, j].TileFrameX = rightX;
        Main.tile[i, j + 1].TileFrameX = baseX;
        Main.tile[i + 1, j + 1].TileFrameX = rightX;

        NetMessage.SendTileSquare(Main.myPlayer, i, j, 2, 2);
    }
}