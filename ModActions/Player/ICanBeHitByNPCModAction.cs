using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanBeHitByNPCModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanBeHitByNPC(NPC npc, ref int cooldownSlot);
}