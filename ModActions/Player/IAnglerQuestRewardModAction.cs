using System.Collections.Generic;
using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IAnglerQuestRewardModAction : IPlayerModAction
{
    int Priority { get; }

    void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems);
}