using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Tiles;

public class FrostCoreBarTile : YggdrasilTile
{
    public override void SetStaticDefaults()
    {
        Main.tileShine[Type] = 1100;
        Main.tileSolid[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.addTile(Type);

        // localized text for "Metal Bar"
        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.MetalBar"));
    }

    public override bool Drop(int i, int j)
    {
        Tile t = Main.tile[i, j];
        int style = t.TileFrameX / 18;

        // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
        if (style == 0)
        {
            Item.NewItem(null, i * 16, j * 16, 16, 16, ModContent.ItemType<FrostCoreBar>());
        }

        return base.Drop(i, j);
    }
}