namespace Yggdrasil.PlayerStats;

public interface IPlayerStat<TValue> : IPlayerStat
{
    TValue Value { get; set; }

    void SetDefaultValue(TValue value);
}