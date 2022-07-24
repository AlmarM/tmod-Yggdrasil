using Terraria;

namespace Yggdrasil.ModHooks.Player;

public interface IPlayerUseSpeedMultiplierModHook : IPlayerModHook
{
    int Priority { get; }

    void PlayerUseSpeedMultiplier(Terraria.Player player, Item item, ref float currentMultiplier);
}