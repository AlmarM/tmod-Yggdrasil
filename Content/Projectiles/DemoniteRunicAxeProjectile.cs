using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Items;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Projectiles;

public class DemoniteRunicAxeProjectile : YggdrasillProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Demonite Runic Axe Projectile");

        // Make the cultist resistant to this Projectile, as it's resistant to all homing Projectiles.
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = false;
    }

    public override void SetDefaults()
    {
        // The ai style of the Projectile (0 means custom AI). For more please reference the source code of Terraria
        Projectile.aiStyle = 0;

        // Can the Projectile deal damage to enemies?
        Projectile.friendly = true;

        // Can the Projectile deal damage to the player?
        Projectile.hostile = false;

        // Can the Projectile collide with tiles?
        Projectile.tileCollide = false;

        // The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
        Projectile.timeLeft = TimeUtils.SecondsToTicks(5);
        Projectile.width = 48;
        Projectile.height = 48;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Projectile.ignoreWater = true;
        Projectile.light = 0.5f;
    }

    public override void AI()
    {
        Projectile.rotation += 0.3f * Projectile.direction;

        var velocityX = Projectile.velocity.X * 0.25f;
        var velocityY = Projectile.velocity.Y * 0.25f;

        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Demonite, velocityX, velocityY,
            150, default, 0.7f);
    }
}