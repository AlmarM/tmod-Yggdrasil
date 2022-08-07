using Terraria;
using Terraria.DataStructures;
using Yggdrasil.ModHooks.Player;

namespace Yggdrasil.PlayerStats;

public class DodgeChanceStat : PlayerStat<float>, IPlayerPreHurtModHook
{
    public int Priority => 1;

    public bool PlayerPreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource,
        ref int cooldownCounter)
    {
        if (damage <= 0 || Main.rand.NextFloat() > Value)
        {
            return true;
        }

        player.NinjaDodge();
        return false;
    }
}