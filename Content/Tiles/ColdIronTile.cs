using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Tiles;

public class ColdIronTile : YggdrasilTile
{
    public override void SetStaticDefaults()
    {
        // The tile will be affected by spelunker highlighting
        Main.tileSpelunker[Type] = false;

        // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
        Main.tileOreFinderPriority[Type] = 700;

        // How often tiny dust appear off this tile. Larger is less frequently
        Main.tileShine[Type] = 975;
        Main.tileMergeDirt[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        //Main.tileShine2[Type] = false; // Modifies the draw color slightly.

        TileID.Sets.Ore[Type] = true;

        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Cold Iron");

        AddMapEntry(new Color(119, 167, 178), name);

        DustType = DustID.Platinum;
        ItemDrop = ModContent.ItemType<ColdIronOre>();
        SoundType = SoundID.Tink;
        MinPick = 200;
        MineResist = 1f;
    }
}