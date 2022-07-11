using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanHitNPCModAction : IPlayerModAction
{
    int Priority { get; }

    bool? CanHitNPC(Item item, NPC target);
}