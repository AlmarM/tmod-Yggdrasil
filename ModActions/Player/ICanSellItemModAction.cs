using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanSellItemModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanSellItem(NPC vendor, Item[] shopInventory, Item item);
}