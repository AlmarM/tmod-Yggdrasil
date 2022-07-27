using Terraria;

namespace Yggdrasil.ModHooks.Player;

public interface IPlayerOnHitByNPCModHook : IPlayerModHook
{
    int Priority { get; }

    void PlayerOnHitByNPC(Terraria.Player player, NPC npc, int damage, bool crit);
}