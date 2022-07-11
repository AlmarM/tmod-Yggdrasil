using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanUseItemModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanUseItem(Item item);
}