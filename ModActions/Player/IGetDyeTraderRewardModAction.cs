using System.Collections.Generic;

namespace Yggdrasil.ModActions.Player;

public interface IGetDyeTraderRewardModAction : IPlayerModAction
{
    int Priority { get; }

    void GetDyeTraderReward(List<int> rewardPool);
}