using System.Collections.Generic;

namespace Yggdrasil.PlayerStats;

public abstract class PlayerStatCollection
{
    public List<IPlayerStat> Hooks { get; }

    protected PlayerStatCollection()
    {
        Hooks = new List<IPlayerStat>();
    }

    public void Reset()
    {
        foreach (IPlayerStat stat in Hooks)
        {
            stat.Reset();
        }
    }

    public abstract void InitializeStats();

    protected T CreateStat<T>() where T : IPlayerStat, new()
    {
        var stat = new T();

        Hooks.Add(stat);

        return stat;
    }
}