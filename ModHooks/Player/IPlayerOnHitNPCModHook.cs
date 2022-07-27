using Terraria;

namespace Yggdrasil.ModHooks.Player;

public interface IPlayerOnHitNPCModHook : IPlayerModHook
{
    int Priority { get; }

    void PlayerOnHitNPC(Terraria.Player player, Item item, NPC target, int damage, float knockback, bool crit);
}