using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Players.Modifiers;

internal class HealthOverTimeModifier : PlayerModifier
{
    public override string Description =>
        MakeDescription(PlayerModifierConfig.HealthOverTimeDescription, _health, _time);

    private int _health;
    private int _time;
    private int _timer;

    public HealthOverTimeModifier(int health, int time)
    {
        _health = health;
        _time = time;
        _timer = 0;
    }

    public override void Apply(Player player)
    {
        if (player.statLife == player.statLifeMax2)
        {
            _timer = 0;

            return;
        }

        if (_timer++ < TimeUtils.SecondsToTicks(_time))
        {
            return;
        }

        _timer = 0;

        player.statLife += _health;
        player.HealEffect(_health);
    }
}