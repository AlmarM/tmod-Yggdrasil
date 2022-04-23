using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Items;

namespace Yggdrasil.Projectiles
{
    public class DemoniteRunicAxeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demonite Runic Axe Projectile");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = false; // Make the cultist resistant to this Projectile, as it's resistant to all homing Projectiles.
        }

		public override void SetDefaults()
		{
			Projectile.width = 48; 
			Projectile.height = 48; 
			Projectile.aiStyle = 0; // The ai style of the Projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>(); 
			Projectile.friendly = true; // Can the Projectile deal damage to enemies?
			Projectile.hostile = false; // Can the Projectile deal damage to the player?
			Projectile.ignoreWater = true; 
			Projectile.light = .5f; 
			Projectile.tileCollide = false; // Can the Projectile collide with tiles?
			Projectile.timeLeft = 300; // The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
		}

        public override void AI()
        {
			Projectile.rotation += 0.3f * (float)Projectile.direction;
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Demonite, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
		}
    }
}