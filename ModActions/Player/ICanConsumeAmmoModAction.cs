using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface ICanConsumeAmmoModAction : IPlayerModAction
{
    int Priority { get; }

    bool CanConsumeAmmo(Item weapon, Item ammo);
}