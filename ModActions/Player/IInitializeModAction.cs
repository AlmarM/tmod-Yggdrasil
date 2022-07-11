namespace Yggdrasil.ModActions.Player;

public interface IInitializeModAction : IPlayerModAction
{
    int Priority { get; }

    void Initialize();
}