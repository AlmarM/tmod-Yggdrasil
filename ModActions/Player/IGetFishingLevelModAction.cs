using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IGetFishingLevelModAction : IPlayerModAction
{
    int Priority { get; }

    void GetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel);
}