using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IGetHealLifeModAction : IPlayerModAction
{
    int Priority { get; }

    void GetHealLife(Item item, bool quickHeal, ref int healValue);
}