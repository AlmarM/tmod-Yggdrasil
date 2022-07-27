using Yggdrasil.ModHooks.Player;
using Yggdrasil.PlayerStats;

namespace Yggdrasil.Content.Players;

public class YggdrasilPlayer : ModHookPlayer
{
    public bool ZoneSvartalvheim { get; set; }

    public EffectsList EffectsList { get; private set; }

    public YggdrasilPlayerStats Stats { get; set; }

    public override void Initialize()
    {
        base.Initialize();

        EffectsList = new EffectsList();

        Stats = new YggdrasilPlayerStats();
        Stats.InitializeStats();
    }

    public override void ResetEffects()
    {
        base.ResetEffects();

        EffectsList.Clear();
        Stats.Reset();
    }

    public override void PreUpdate()
    {
        AddStatHooks();
    }

    private void AddStatHooks()
    {
        foreach (IPlayerStat stat in Stats.Hooks)
        {
            AddModHooks(stat);
        }
    }
}