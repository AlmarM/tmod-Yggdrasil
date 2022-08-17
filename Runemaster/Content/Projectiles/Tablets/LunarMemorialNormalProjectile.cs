using Terraria;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class LunarMemorialNormalProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = 55;
        Projectile.alpha = 255;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        int choice = Main.rand.Next(4);
        float r = 0f;
        float g = 0f;
        float b = 0f;
        float size = 1.5f;

        if (choice == 0)
        {
            choice = 71; //Nebula
            r = .45f;
            g = .25f;
            b = .45f;
        }
        else if (choice == 1)
        {
            choice = 259; //Solar
            r = .5f;
            g = .25f;
            b = .1f;
        }
        else if (choice == 2)
        {
            choice = 229; //Vortex
            r = .05f;
            g = .45f;
            b = .2f;
        }
        else
        {
            choice = 226; //Stardust
            r = 0f;
            g = .25f;
            b = .45f;
            size = 1f;
        }

        // Spawn the dust
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, choice,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, size);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, r, g, b);
    }
}