using Terraria;

namespace Yggdrasil.ModHooks.Player;

public interface IPlayerOnHitNPCWithProjModHook : IPlayerModHook
{
    int Priority { get; }

    void PlayerOnHitNPCWithProj(Terraria.Player player, Projectile proj, NPC target, int damage, float knockback, bool crit);
}