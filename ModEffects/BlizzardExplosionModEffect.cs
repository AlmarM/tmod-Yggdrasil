using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Projectiles.Magic;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Runemaster.Content.Projectiles;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.ModEffects;

public class BlizzardExplosionModEffect : IPlayerOnHitNPCWithProjModHook
{
    public int Priority { get; }

    public string EffectDescription
    {
        get
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            return $"Critical hit caused by {runicText} weapons releases many frost sparks";
        }
    }

    private readonly Item _source;

    public BlizzardExplosionModEffect(Item source)
    {
        _source = source;
    }

    public void PlayerOnHitNPCWithProj(Player player, Projectile proj, NPC target, int damage, float knockback,
        bool crit)
    {
        if (proj.ModProjectile is not RuneTabletProjectile || !crit)
        {
            return;
        }

        CreateBlizzardExplosionAroundEntity(player, 5, 6f, 25f, target);
    }

    private void CreateBlizzardExplosionAroundEntity(Player player, int projectileCount, float projectileSpeed,
        float radius, Entity entity)
    {
        float delta = MathF.PI * 2 / projectileCount;

        for (var i = 0; i < projectileCount; i++)
        {
            float theta = delta * i;
            var position = entity.Center + Vector2.One.RotatedBy(theta) * radius;

            Vector2 direction = position - entity.Center;
            direction = Vector2.Normalize(direction);
            direction = Vector2.Multiply(direction, projectileSpeed);

            var projectileType = ModContent.ProjectileType<GlacierStaffProjectile>();
            Projectile.NewProjectile(player.GetSource_Accessory(_source), position, direction, projectileType, 15, 2,
                player.whoAmI);
        }
    }
}