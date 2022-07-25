using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Svartalvheim.Content.Items.Blocks;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimWallTile : YggdrasilWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		ItemDrop = ModContent.ItemType<SvartalvheimWall>();
		AddMapEntry(new Color(59, 38, 29));
	}

}