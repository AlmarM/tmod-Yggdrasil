using Terraria;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Utils;

namespace Yggdrasil.PlayerStats;

public class InvincibilityTimeStat : PlayerStat<float>, IPlayerPostHurtModHook
{
    public int Priority { get; }

    public void PlayerPostHurt(Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit,
        int cooldownCounter)
    {
        if (Value <= 0)
        {
            return;
        }

        int bonusTicks = TimeUtils.SecondsToTicks(Value);
        player.immuneTime += bonusTicks;
    }
}