namespace Yggdrasil.ModActions.Player;

public interface IHurtModAction : IPlayerModAction
{
    int Priority { get; }

    void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit);
}