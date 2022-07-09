using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Yggdrasil.ModActions.Player;

public class ModActionPlayer : ModPlayer
{
    private IDictionary<Type, IList<IPlayerModAction>> _modActionMap;

    public override void Initialize()
    {
        _modActionMap = new Dictionary<Type, IList<IPlayerModAction>>();
    }

    public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
    {
        IEnumerable<IAddStartingItemsModAction> modActions = FilterModActions<IAddStartingItemsModAction>()
            .OrderByDescending(ma => ma.Priority);

        List<Item> startingItems = base.AddStartingItems(mediumCoreDeath).ToList();

        foreach (IAddStartingItemsModAction modAction in modActions)
        {
            startingItems.AddRange(modAction.AddStartingItems(mediumCoreDeath));
        }

        return startingItems;
    }

    public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
    {
        IEnumerable<IAnglerQuestRewardModAction> modActions = FilterModActions<IAnglerQuestRewardModAction>()
            .OrderByDescending(ma => ma.Priority);

        base.AnglerQuestReward(rareMultiplier, rewardItems);

        foreach (IAnglerQuestRewardModAction modAction in modActions)
        {
            modAction.AnglerQuestReward(rareMultiplier, rewardItems);
        }
    }

    public override bool? CanAutoReuseItem(Item item)
    {
        IEnumerable<ICanAutoReuseItemModAction> modActions = FilterModActions<ICanAutoReuseItemModAction>()
            .OrderByDescending(ma => ma.Priority);

        foreach (ICanAutoReuseItemModAction modAction in modActions)
        {
            bool? canAutoReuseItem = modAction.CanAutoReuseItem(item);
            if (canAutoReuseItem.HasValue)
            {
                return canAutoReuseItem;
            }
        }

        return base.CanAutoReuseItem(item);
    }

    protected virtual void CreateModActions()
    {
    }

    protected void AddModAction(IPlayerModAction modAction)
    {
        var key = modAction.GetType();
        if (_modActionMap.ContainsKey(key))
        {
            _modActionMap[key].Add(modAction);
        }
        else
        {
            _modActionMap.Add(key, new List<IPlayerModAction>(new[] { modAction }));
        }
    }

    private IEnumerable<T> FilterModActions<T>()
    {
        return _modActionMap[typeof(T)].Cast<T>();
    }
}