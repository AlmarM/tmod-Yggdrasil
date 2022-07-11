using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanBuyItemModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanBuyItem(NPC vendor, Item[] shopInventory, Item item);
}