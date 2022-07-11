using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanHitPvpWithProjModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanHitPvpWithProj(Projectile proj, Terraria.Player target);
}