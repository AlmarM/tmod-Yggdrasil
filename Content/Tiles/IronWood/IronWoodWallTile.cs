using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodWallTile : YggdrasilWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		WallID.Sets.Conversion.Grass[Type] = true;
		ItemDrop = ModContent.ItemType<IronWoodWall>();
		AddMapEntry(new Color(65, 65, 65));
	}

}