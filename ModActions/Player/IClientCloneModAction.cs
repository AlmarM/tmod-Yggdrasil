using Terraria.ModLoader;

namespace Yggdrasil.ModActions.Player;

public interface IClientCloneModAction : IPlayerModAction
{
    int Priority { get; }

    void ClientClone(ModPlayer clientClone);
}