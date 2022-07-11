using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IGetHealManaModAction : IPlayerModAction
{
    int Priority { get; }

    void GetHealMana(Item item, bool quickHeal, ref int healValue);
}