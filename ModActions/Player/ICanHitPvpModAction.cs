using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanHitPvpModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanHitPvp(Item item, Terraria.Player target);
}