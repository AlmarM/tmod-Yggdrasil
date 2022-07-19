using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Tiles;

public class NordicGrassRoofTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		//TileID.Sets.Ore[Type] = true;
		Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
		//Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
		//Main.tileShine2[Type] = false; // Modifies the draw color slightly.
		//Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
		Main.tileMergeDirt[Type] = false;
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;

		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Nordic Grass Roff");
		AddMapEntry(new Color(82, 73, 69), name);

		DustType = DustID.Dirt;
		ItemDrop = ModContent.ItemType<NordicGrassRoof>();
		//soundType = SoundID.Tink;
		//soundStyle = 1;


	}
}