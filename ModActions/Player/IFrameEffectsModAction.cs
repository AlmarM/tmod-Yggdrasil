namespace Yggdrasil.ModActions.Player;

public interface IFrameEffectsModAction : IPlayerModAction
{
    int Priority { get; }

    void FrameEffects();
}