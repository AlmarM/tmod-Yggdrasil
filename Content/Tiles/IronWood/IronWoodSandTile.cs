using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodSandTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlendAll[this.Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileLighted[Type] = true;

		AddMapEntry(new Color(159, 149, 143));

		DustType = DustID.Stone;
		ItemDrop = ModContent.ItemType<IronWoodSand>();



	}
}