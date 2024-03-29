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
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 700;
        Main.tileShine[Type] = 975;
        Main.tileMergeDirt[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.Ore[Type] = true;

        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Cold Iron");
        AddMapEntry(new Color(255, 0, 255), name);
        //AddMapEntry(new Color(57, 78, 132), name);

        DustType = DustID.Platinum;
        ItemDrop = ModContent.ItemType<ColdIronOre>();
        MinPick = 225;
        MineResist = 1f;
    }
}