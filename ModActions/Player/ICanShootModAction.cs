using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanShootModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanShoot(Item item);
}