using Terraria.DataStructures;

namespace Yggdrasil.ModActions.Player;

public interface IKillModAction : IPlayerModAction
{
    int Priority { get; }

    void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource);
}