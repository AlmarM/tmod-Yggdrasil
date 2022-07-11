using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanHitNPCWithProjModAction : IPlayerModAction
{
    int Priority { get; }

    bool? CanHitNPCWithProj(Projectile proj, NPC target);
}