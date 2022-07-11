using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IModifyCaughtFishModAction : IPlayerModAction
{
    int Priority { get; }

    void ModifyCaughtFish(Item fish);
}