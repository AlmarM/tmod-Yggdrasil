using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodTile : YggdrasilTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlendAll[this.Type] = false;
		Main.tileBlockLight[Type] = true;
		Main.tileLighted[Type] = true;

		AddMapEntry(new Color(23, 21, 19));

		DustType = DustID.Stone;
		ItemDrop = ModContent.ItemType<IronWoodItem>();
	}

}