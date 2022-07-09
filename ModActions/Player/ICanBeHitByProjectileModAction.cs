using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanBeHitByProjectileModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanBeHitByProjectile(Projectile proj);
}