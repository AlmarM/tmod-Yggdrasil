using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;

namespace Yggdrasil.Content.Projectiles.Summon
{
	public class DwarfSpiritSummonProjectile : YggdrasilProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dwarf Spirit");
			Main.projPet[Projectile.type] = true; // Denotes that this projectile is a pet or minion
			Main.projFrames[Projectile.type] = 8;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true; // This is necessary for right-click targeting
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		public override void SetDefaults()
		{
			AIType = ProjectileID.Raven;
			Projectile.CloneDefaults(ProjectileID.Raven);
			Projectile.minion = true; // Declares this as a minion (has many effects)
			Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
			Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.netImportant = true;
			Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
			Projectile.minionSlots = 1f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
										 //Projectile.alpha = 0;
		}

		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles() => false;

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.penetrate == 0)
				Projectile.Kill();
			return false;
		}

		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage()
		{
			return true;
		}

		public override void AI()
		{
			Player owner = Main.player[Projectile.owner];

			if (!CheckActive(owner))
			{
				return;
			}

		}

		// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
		private bool CheckActive(Player owner)
		{
			if (owner.dead || !owner.active)
			{
				owner.ClearBuff(ModContent.BuffType<DwarfSpiritSummonBuff>());

				return false;
			}

			if (owner.HasBuff(ModContent.BuffType<DwarfSpiritSummonBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			return true;
		}

		//This doesn't seem to really work?
		private void Visuals()
		{
			Lighting.AddLight(Projectile.Center, Color.AliceBlue.ToVector3() * 1f);
		}
	}
}