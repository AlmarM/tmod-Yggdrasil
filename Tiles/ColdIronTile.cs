using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Tiles
{
	public class ColdIronTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 700; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			//Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cold Iron");
			AddMapEntry(new Color(119, 167, 178), name);

			DustType = 84;
			ItemDrop = ModContent.ItemType<Items.Placeable.ColdIronOre>();
			SoundType = SoundID.Tink;
            MinPick = 200;
            MineResist = 1f;
			
		}
	}
}