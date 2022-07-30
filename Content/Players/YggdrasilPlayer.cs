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

        AddStatHooks();
    }

    private void AddStatHooks()
    {
        foreach (IPlayerModHook stat in Stats.Hooks)
        {
            AddModHooks(stat);
        }
    }
}