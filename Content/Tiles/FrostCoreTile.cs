using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Frostcore.Content.Items.Ores;

namespace Yggdrasil.Content.Tiles;

public class FrostCoreTile : YggdrasilTile
{
    public override void SetStaticDefaults()
    {
        // The tile will be affected by spelunker highlighting
        Main.tileSpelunker[Type] = true;

        // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
        Main.tileOreFinderPriority[Type] = 400;

        // How often tiny dust appear off this tile. Larger is less frequently
        Main.tileShine[Type] = 975;
        Main.tileMergeDirt[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        //Main.tileShine2[Type] = false; // Modifies the draw color slightly.

        TileID.Sets.Ore[Type] = true;

        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Frostcore");

        AddMapEntry(new Color(51, 255, 255), name);

        DustType = DustID.NorthPole;
        ItemDrop = ModContent.ItemType<FrostcoreOre>();
        //SoundType = SoundID.Tink;
        MinPick = 55;
        MineResist = 1f;
    }
}