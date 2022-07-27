namespace Yggdrasil.PlayerStats;

public abstract class PlayerStat<TValue> : IPlayerStat<TValue>
{
    public TValue Value { get; set; }

    protected TValue defaultValue;

    public void SetDefaultValue(TValue value)
    {
        defaultValue = value;
    }

    public void Reset()
    {
        Value = defaultValue;
    }
}