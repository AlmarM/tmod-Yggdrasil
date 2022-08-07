﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Nordic.Content.Projectiles;

public class NordicSpearProjectile : YggdrasilProjectile
{
    protected virtual float HoldoutRangeMin => 24f;
    protected virtual float HoldoutRangeMax => 250;

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nordic Spear Projectile");
    }

    public override void SetDefaults()
    {
        //Projectile.CloneDefaults(ProjectileID.Spear);
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.aiStyle = 19;
        Projectile.penetrate = -1;
        Projectile.scale = 1.3f;
        Projectile.alpha = 0;

        Projectile.hide = true;
        Projectile.ownerHitCheck = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.tileCollide = false;
        Projectile.friendly = true;
    }

    public override bool PreAI()
    {
        // Since we access the owner player instance so much, it's useful to create a helper local variable for this
        Player player = Main.player[Projectile.owner];

        // Define the duration the projectile will exist in frames
        int duration = player.itemAnimationMax;

        // Update the player's held projectile id
        player.heldProj = Projectile.whoAmI;

        // Reset projectile time left if necessary
        if (Projectile.timeLeft > duration)
        {
            Projectile.timeLeft = duration;
        }

        // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.
        Projectile.velocity = Vector2.Normalize(Projectile.velocity);

        float halfDuration = duration * 0.5f;
        float progress;

        // Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
        if (Projectile.timeLeft < halfDuration)
        {
            progress = Projectile.timeLeft / halfDuration;
        }
        else
        {
            progress = (duration - Projectile.timeLeft) / halfDuration;
        }

        // Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
        Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin,
            Projectile.velocity * HoldoutRangeMax, progress);

        // Apply proper rotation to the sprite.
        if (Projectile.spriteDirection == -1)
        {
            // If sprite is facing left, rotate 45 degrees
            Projectile.rotation += MathHelper.ToRadians(45f);
        }
        else
        {
            // If sprite is facing right, rotate 135 degrees
            Projectile.rotation += MathHelper.ToRadians(135f);
        }

        return false; // Don't execute vanilla AI.
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Frostburn, TimeUtils.SecondsToTicks(10));
        target.AddBuff(ModContent.BuffType<SlowDebuff>(), TimeUtils.SecondsToTicks(1.5f));
    }
}