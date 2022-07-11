using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace Yggdrasil.ModActions.Player;

public interface ICatchFishModAction : IPlayerModAction
{
    int Priority { get; }

    void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar,
        ref Vector2 sonarPosition);
}