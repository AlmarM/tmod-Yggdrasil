using Yggdrasil.ModHooks.Player;

namespace Yggdrasil.PlayerStats;

public interface IPlayerStat : IPlayerModHook
{
    void Reset();
}