using Terraria.DataStructures;

namespace Yggdrasil.ModHooks.Player;

public interface IPlayerPreHurtModHook : IPlayerModHook
{
    int Priority { get; }

    bool PlayerPreHurt(Terraria.Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection,
        ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource,
        ref int cooldownCounter);
}