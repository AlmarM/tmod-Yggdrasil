namespace Yggdrasil.PlayerStats;

public class YggdrasilPlayerStats : PlayerStatCollection
{
    public DodgeChanceStat DodgeChance { get; private set; }

    public InvincibilityTimeStat InvincibilityTime { get; private set; }

    public NoAmmoConsumptionChanceStat NoAmmoConsumptionChance { get; private set; }

    public ApplyRandomBuffStat ApplyRandomBuff { get; private set; }

    public override void InitializeStats()
    {
        DodgeChance = CreateStat<DodgeChanceStat>();
        InvincibilityTime = CreateStat<InvincibilityTimeStat>();
        NoAmmoConsumptionChance = CreateStat<NoAmmoConsumptionChanceStat>();
        ApplyRandomBuff = CreateStat<ApplyRandomBuffStat>();
    }
}