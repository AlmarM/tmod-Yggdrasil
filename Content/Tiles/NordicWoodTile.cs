using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Content.Tiles;

public class NordicWoodTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		//TileID.Sets.Ore[Type] = true;
		Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
		//Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
		//Main.tileShine2[Type] = false; // Modifies the draw color slightly.
		//Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
		Main.tileMergeDirt[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;

		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Nordic Wood");
		AddMapEntry(new Color(82, 73, 69), name);

		DustType = 84;
		ItemDrop = ModContent.ItemType<NordicWood>();
		//soundType = SoundID.Tink;
		//soundStyle = 1;


	}
}