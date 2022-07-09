using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.IronWood;

namespace Yggdrasil.Content.Projectiles;

public class IronWoodSolutionProjectile : YggdrasilProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Iron Wood Solution");
	}

	public override void SetDefaults()
	{
		Projectile.width = 6;
		Projectile.height = 6;
		Projectile.friendly = true;
		Projectile.alpha = 255;
		Projectile.penetrate = -1;
		Projectile.extraUpdates = 2;
		Projectile.tileCollide = false;
		Projectile.ignoreWater = true;
	}

	public override void AI()
	{
		//Set the dust type to ExampleSolution
		int dustType = DustID.Stone;

		if (Projectile.owner == Main.myPlayer)
			Convert((int)(Projectile.position.X + Projectile.width / 2) / 16, (int)(Projectile.position.Y + Projectile.height / 2) / 16, 2);

		if (Projectile.timeLeft > 133)
			Projectile.timeLeft = 133;

		if (Projectile.ai[0] > 7f)
		{
			float dustScale = 1f;

			if (Projectile.ai[0] == 8f)
				dustScale = 0.2f;
			else if (Projectile.ai[0] == 9f)
				dustScale = 0.4f;
			else if (Projectile.ai[0] == 10f)
				dustScale = 0.6f;
			else if (Projectile.ai[0] == 11f)
				dustScale = 0.8f;

			Projectile.ai[0] += 1f;

			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
				Dust dust = Main.dust[dustIndex];
				dust.noGravity = true;
				dust.scale *= 1.75f;
				dust.velocity.X *= 2f;
				dust.velocity.Y *= 2f;
				dust.scale *= dustScale;
			}
		}
		else
			Projectile.ai[0] += 1f;

		Projectile.rotation += 0.3f * Projectile.direction;
	}

	public void Convert(int i, int j, int size = 4)
	{
		for (int k = i - size; k <= i + size; k++)
		{
			for (int l = j - size; l <= j + size; l++)
			{
				if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size))
				{
					int type = Main.tile[k, l].TileType;
					int wall = Main.tile[k, l].WallType;

					//Convert all walls to ExampleWall
					if (wall != 0)
					{
						Main.tile[k, l].WallType = (ushort)ModContent.WallType<IronWoodWallTile>();
						WorldGen.SquareWallFrame(k, l, true);
						NetMessage.SendTileSquare(-1, k, l, 1);
					}

					//If the tile is stone, convert to ExampleBlock
					if (TileID.Sets.Conversion.Stone[type])
					{
						Main.tile[k, l].TileType = (ushort)ModContent.TileType<IronWoodStoneTile>();
						WorldGen.SquareTileFrame(k, l, true);
						NetMessage.SendTileSquare(-1, k, l, 1);
					}
					//If the tile is sand, convert to ExampleSand
					else if (TileID.Sets.Conversion.Sand[type])
					{
						Main.tile[k, l].TileType = (ushort)ModContent.TileType<IronWoodSandTile>();
						WorldGen.SquareTileFrame(k, l, true);
						NetMessage.SendTileSquare(-1, k, l, 1);
					}

					else if (TileID.Sets.Conversion.Ice[type])
					{
						Main.tile[k, l].TileType = (ushort)ModContent.TileType<IronWoodIceTile>();
						WorldGen.SquareTileFrame(k, l, true);
						NetMessage.SendTileSquare(-1, k, l, 1);
					}
					else if (TileID.Sets.Conversion.Grass[type])
					{
						Main.tile[k, l].TileType = (ushort)ModContent.TileType<IronWoodGrassTile>();
						WorldGen.SquareTileFrame(k, l, true);
						NetMessage.SendTileSquare(-1, k, l, 1);
					}
				}
			}
		}
	}
}