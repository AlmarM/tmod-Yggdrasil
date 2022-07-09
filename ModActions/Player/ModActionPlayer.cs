using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Yggdrasil.ModActions.Player;

public abstract class ModActionPlayer : ModPlayer
{
    private IDictionary<Type, IList<IPlayerModAction>> _modActionMap;

    public override void Initialize()
    {
        _modActionMap = new Dictionary<Type, IList<IPlayerModAction>>();

        CreateModActions();
    }

    // public override ModPlayer NewInstance(Terraria.Player entity)
    // {
    //     ModPlayer newInstance = base.NewInstance(entity);
    //     ModActionPlayer modActionPlayer = (ModActionPlayer)newInstance;
    //
    //     modActionPlayer._modActionMap = new Dictionary<Type, IList<IPlayerModAction>>();
    //     modActionPlayer.CreateModActions();
    //
    //     return modActionPlayer;
    // }

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
        Type baseType = typeof(IPlayerModAction);
        Type[] modActionTypes = modAction
            .GetType()
            .GetInterfaces()
            .Where(it => it.IsAssignableTo(baseType) && it != baseType)
            .ToArray();

        foreach (Type type in modActionTypes)
        {
            if (_modActionMap.ContainsKey(type))
            {
                _modActionMap[type].Add(modAction);
            }
            else
            {
                _modActionMap.Add(type, new List<IPlayerModAction>(new[] { modAction }));
            }
        }
    }

    private IEnumerable<T> FilterModActions<T>()
    {
        var type = typeof(T);
        return _modActionMap.ContainsKey(type)
            ? _modActionMap[type].Cast<T>()
            : Enumerable.Empty<T>();
    }
}