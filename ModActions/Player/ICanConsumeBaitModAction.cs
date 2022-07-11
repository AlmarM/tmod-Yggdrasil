using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanConsumeBaitModAction : IPlayerModAction
{
    int Priority { get; }

    bool? CanConsumeBait(Item bait);
}