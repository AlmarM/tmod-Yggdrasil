using Terraria;

namespace Yggdrasil.ModHooks.Player;

public interface IPlayerCanConsumeAmmoModHook : IPlayerModHook
{
    int Priority { get; }

    bool PlayerCanConsumeAmmo(Terraria.Player player, Item weapon, Item ammo);
}