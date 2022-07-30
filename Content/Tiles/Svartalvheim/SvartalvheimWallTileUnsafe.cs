using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.World.Svartalvheim.Content.Items.Blocks;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimWallTileUnsafe : YggdrasilWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = false;
		ItemDrop = ModContent.ItemType<SvartalvheimWall>();
		AddMapEntry(new Color(59, 38, 29));
	}

	public override bool CanExplode(int i, int j) => false;

}