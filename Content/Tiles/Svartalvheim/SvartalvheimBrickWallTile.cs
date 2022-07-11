using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.Svartalvheim;

namespace Yggdrasil.Content.Tiles.Svartalvheim;

public class SvartalvheimBrickWallTile : YggdrasilWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		WallID.Sets.Conversion.Grass[Type] = true;
		ItemDrop = ModContent.ItemType<SvartalvheimBrickWall>();
		AddMapEntry(new Color(96, 46, 46));
	}

}