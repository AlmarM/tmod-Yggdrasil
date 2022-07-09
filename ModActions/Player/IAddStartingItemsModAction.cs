using System.Collections.Generic;
using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IAddStartingItemsModAction : IPlayerModAction
{
    int Priority { get; }

    IEnumerable<Item> AddStartingItems(bool mediumCoreDeath);
}