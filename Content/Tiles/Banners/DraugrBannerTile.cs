using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Snow;
using System;

namespace Yggdrasil.Content.Tiles.Banners
{
	public class DraugrBannerTile : YggdrasilTile
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
			name.SetDefault("Draugr Banner");
			AddMapEntry(new Color(29, 240, 255), name);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<DraugrBanner>());
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				Main.SceneMetrics.NPCBannerBuff[ModContent.NPCType<Draugr>()] = true;
				Main.SceneMetrics.NPCBannerBuff[ModContent.NPCType<DraugrElite>()] = true;
				Main.SceneMetrics.hasBanner = true;
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}
