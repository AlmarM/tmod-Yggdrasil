using Terraria;
using Terraria.ID;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class BloodySlabProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = 25;
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        //Lighting.AddLight(Projectile.position, 0, 0.4f, 0.4f);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        var healing = 1;
        Player player = Main.player[Projectile.owner];

        if (player.statLife < player.statLifeMax2)
        {
            if (Main.rand.NextFloat() < .1f)
            {
                player.statLife += healing;
                player.HealEffect(healing);
            }
        }
    }
}