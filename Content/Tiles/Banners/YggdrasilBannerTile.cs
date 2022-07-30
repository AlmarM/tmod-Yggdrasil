using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Yggdrasil.Content.Tiles.Banners;

public abstract class YggdrasilBannerTile : YggdrasilTile
{
    protected abstract int BannerType { get; }

    protected abstract int[] NpcTypes { get; }

    protected abstract string MapEntryName { get; }

    protected abstract Color MapEntryColor { get; }

    public override void SetStaticDefaults()
    {
        DustType = -1;

        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;

        var anchorFlags = AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom;
        TileObjectData.newTile.AnchorTop = new AnchorData(anchorFlags, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.addTile(Type);

        ModTranslation name = CreateMapEntryName();
        name.SetDefault(MapEntryName);

        AddMapEntry(MapEntryColor, name);
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        var source = new EntitySource_TileBreak(i, j);
        Item.NewItem(source, i * 16, j * 16, 16, 48, BannerType);
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (!closer)
        {
            return;
        }

        foreach (int type in NpcTypes)
        {
            Main.SceneMetrics.NPCBannerBuff[type] = true;
        }

        Main.SceneMetrics.hasBanner = true;
    }

    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
    {
        if (i % 2 == 1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }
}