using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles
{
    public class WoodLanceProjectile : YggdrasilProjectile
    {
        protected virtual float HoldoutRangeMin => 80f;
        protected virtual float HoldoutRangeMax => 160f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runic Shiny Spear");
        }

        public override void SetDefaults()
        {
            //Projectile.CloneDefaults(ProjectileID.Spear);
            //Projectile.width = 20;
            //Projectile.height = 20;
            Projectile.aiStyle = 19;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            Projectile.alpha = 0;

            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
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
            float rangeMaxBonus = 0f;
            if (player.HasBuff<DefensiveStanceBuff>())
            {
                rangeMaxBonus += 300f;
            }

            Vector2 holdoutRangeMin = Projectile.velocity * HoldoutRangeMin;
            Vector2 holdoutRangeMax = Projectile.velocity * (HoldoutRangeMax + rangeMaxBonus);
            var smoothStep = Vector2.SmoothStep(holdoutRangeMin, holdoutRangeMax, progress);

            Projectile.Center = player.MountedCenter + smoothStep;

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

            // Don't execute vanilla AI.
            return false;
        }
    }
}