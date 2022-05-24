using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Yggdrasil.Utils;
using Terraria.ID;

namespace Yggdrasil.Content.Projectiles;

public class RunicPunctureProjectile : YggdrasilProjectile
{
    private float Distance
    {
        get => Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }

    public override void SetDefaults()
    {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.friendly = true;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.penetrate = 4;
        Projectile.timeLeft = TimeUtils.SecondsToTicks(0.27f);
    }

    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
    {
        Player player = Main.player[Projectile.owner];
        Vector2 unit = Projectile.velocity;
        unit.Normalize();

        Distance = (Projectile.Center - player.Center).Length();

        // Not used but needed by CheckAABBvLineCollision()
        float point = 0f;

        return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center,
            player.Center + unit * Distance, Projectile.width, ref point);
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Player player = Main.player[Projectile.owner];
        Texture2D text = TextureAssets.Projectile[Projectile.type].Value;

        DelegateMethods.f_1 = 1f;
        DelegateMethods.c_1 = Color.White;
        DelegateMethods.i_1 = 0;

        Terraria.Utils.DrawLaser(Main.spriteBatch, text, player.Center - Main.screenPosition,
            Projectile.Center - Main.screenPosition,
            new Vector2(1f), DelegateMethods.TurretLaserDraw);

        return false;
    }

    public override void PostAI()
    {
        for (int i = 0; i < 3; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height,
                DustID.RainCloud,
                Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
        }
    }
}