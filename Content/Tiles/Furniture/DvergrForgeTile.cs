using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Content.Items.Furniture;

namespace Yggdrasil.Content.Tiles.Furniture;

public class DvergrForgeTile : YggdrasilTile
{
    public override void SetStaticDefaults()
    {
        // Properties
        Main.tileTable[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileLighted[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;

        DustType = DustID.Frost;
        //AdjTiles = new int[] { TileID.WorkBenches };

        // Placement
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
        TileObjectData.addTile(Type);

        //AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        // Etc
        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Dvergr Forge");
        AddMapEntry(new Color(29, 240, 255), name);
        
        AnimationFrameHeight = 38;
    }

    public override void NumDust(int x, int y, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }

    public override void KillMultiTile(int x, int y, int frameX, int frameY)
    {
        Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 16, ModContent.ItemType<DvergrForge>());
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 9) //replace 10 with duration of frame in ticks
        {
            frameCounter = 0;
            frame++;
            frame %= 8;
        }
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.1f;
        g = 0.85f;
        b = 0.9f;
    }
}