using Terraria;
using Yggdrasil.ModHooks.Player;

namespace Yggdrasil.PlayerStats;

public class NoAmmoConsumptionChanceStat : PlayerStat<float>, IPlayerCanConsumeAmmoModHook
{
    public int Priority { get; }

    public bool PlayerCanConsumeAmmo(Player player, Item weapon, Item ammo)
    {
        return Main.rand.NextFloat() > Value;
    }
}