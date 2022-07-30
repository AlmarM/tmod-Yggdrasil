using System;

namespace Yggdrasil.PlayerStats;

public abstract class PlayerStat<TValue> : IPlayerStat<TValue>
{
    public TValue Value { get; set; }

    protected TValue defaultValue;

    public PlayerStat()
    {
        if (!typeof(TValue).IsValueType)
        {
            defaultValue = Activator.CreateInstance<TValue>();
            Value = Activator.CreateInstance<TValue>();
        }
    }

    public void SetDefaultValue(TValue value)
    {
        defaultValue = value;
    }

    public virtual void Reset()
    {
        Value = defaultValue;
    }
}