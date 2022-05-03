/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Content.Items.Banners;
using System;

namespace Yggdrasil.Content.Tiles.Banners
{
	public class BannersTile : YggdrasilTile
	{
        public override void SetStaticDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };		
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);

			DustType = -1;
			TileID.Sets.DisableSmartCursor[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameX / 18;
			if (style == 0)
			{
				Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<VikingBanner>());
			}
			else if (style == 1)
			{
				Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<DraugrBanner>());
			}

		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].TileFrameX / 18;
				if (style == 0)
				{
					player.HasNPCBannerBuff(ModContent.ItemType<VikingBanner>()); // @todo THIS CRASHES THE GAME
					//player.hasBanner = true;
				}
				else if (style == 1)
				{
					player.HasNPCBannerBuff(ModContent.ItemType<DraugrBanner>());
				}
				
			}
		}
	}
}*/
