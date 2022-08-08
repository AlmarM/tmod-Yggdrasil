namespace Yggdrasil.ModHooks.Player;

public interface IPlayerPostHurtModHook : IPlayerModHook
{
    int Priority { get; }

    void PlayerPostHurt(Terraria.Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit,
        int cooldownCounter);
}