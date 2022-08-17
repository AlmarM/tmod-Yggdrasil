using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Projectiles.Tools;

public class DvergrHookProjectile : YggdrasilProjectile
{
    private static Asset<Texture2D> chainTexture;

    public override void Load()
    {
        // This is called once on mod (re)load when this piece of content is being loaded.
        // This is the path to the texture that we'll use for the hook's chain. Make sure to update it.
        chainTexture = ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/Projectiles/Tools/DvergrHookChain");
    }

    public override void Unload()
    {
        // This is called once on mod reload when this piece of content is being unloaded.
        // It's currently pretty important to unload your static fields like this, to avoid having parts of your mod remain in memory when it's been unloaded.
        chainTexture = null;
    }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("${ProjectileName.GemHookAmethyst}");
    }

    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
    }

    // Use this hook for hooks that can have multiple hooks mid-flight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook.
    public override bool? CanUseGrapple(Player player)
    {
        int hooksOut = 0;
        for (int l = 0; l < 1000; l++)
        {
            if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer &&
                Main.projectile[l].type == Projectile.type)
            {
                hooksOut++;
            }
        }

        return hooksOut <= 2;
    }

    // Amethyst Hook is 300, Static Hook is 600.
    public override float GrappleRange()
    {
        return 800f;
    }

    public override void NumGrappleHooks(Player player, ref int numHooks)
    {
        // The amount of hooks that can be shot out
        numHooks = 2;
    }

    public override void GrappleRetreatSpeed(Player player, ref float speed)
    {
        // How fast the grapple returns to you after meeting its max shoot distance
        speed = 18f;
    }

    public override void GrapplePullSpeed(Player player, ref float speed)
    {
        if (Main.rand.NextBool(8))
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, DustID.GemRuby);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust].scale *= 1.5f;
        }

        player.endurance += 0.05f;

        // How fast you get pulled to the grappling hook projectile's landing position
        speed = 10;
    }

    // Adjusts the position that the player will be pulled towards. This will make them hang 50 pixels away from the tile being grappled.
    public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
    {
        Vector2 dirToPlayer = Projectile.DirectionTo(player.Center);
        float hangDist = 50f;
        grappleX += dirToPlayer.X * hangDist;
        grappleY += dirToPlayer.Y * hangDist;
    }

    // Draws the grappling hook's chain.
    public override bool PreDrawExtras()
    {
        Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
        Vector2 center = Projectile.Center;
        Vector2 directionToPlayer = playerCenter - Projectile.Center;
        float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
        float distanceToPlayer = directionToPlayer.Length();

        while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
        {
            directionToPlayer /= distanceToPlayer; // get unit vector
            directionToPlayer *= chainTexture.Height(); // multiply by chain link length

            center += directionToPlayer; // update draw position
            directionToPlayer = playerCenter - center; // update distance
            distanceToPlayer = directionToPlayer.Length();

            Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

            // Draw chain
            Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition,
                chainTexture.Value.Bounds, drawColor, chainRotation,
                chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
        }

        // Stop vanilla from drawing the default chain.
        return false;
    }
}