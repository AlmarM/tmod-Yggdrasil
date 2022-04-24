using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;


namespace Yggdrasil.Tiles
{
	public class FrostCoreTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 400; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			//Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Frostcore");
			AddMapEntry(new Color(51, 255, 255), name);

			DustType = 84;
			ItemDrop = ModContent.ItemType<Items.Placeable.FrostCoreOre>();
			SoundType = SoundID.Tink;
            MinPick = 50;
            MineResist = 1f;
			
		}
	}
}