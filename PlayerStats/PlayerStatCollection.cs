using System.Collections.Generic;
using Yggdrasil.ModHooks.Player;

namespace Yggdrasil.PlayerStats;

public abstract class PlayerStatCollection
{
    public List<IPlayerModHook> Hooks { get; }

    private readonly List<IPlayerStat> _stats;

    protected PlayerStatCollection()
    {
        Hooks = new List<IPlayerModHook>();

        _stats = new List<IPlayerStat>();
    }

    public void Reset()
    {
        foreach (IPlayerStat stat in _stats)
        {
            stat.Reset();
        }
    }

    public abstract void InitializeStats();

    protected T CreateStat<T>() where T : IPlayerStat, IPlayerModHook, new()
    {
        var stat = new T();

        Hooks.Add(stat);
        _stats.Add(stat);

        return stat;
    }
}