using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanAutoReuseItemModAction : IPlayerModAction
{
    int Priority { get; }

    bool? CanAutoReuseItem(Item item);
}