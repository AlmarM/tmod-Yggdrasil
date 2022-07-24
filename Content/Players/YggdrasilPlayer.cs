using Yggdrasil.ModHooks.Player;

namespace Yggdrasil.Content.Players;

public class YggdrasilPlayer : ModHookPlayer
{
    public bool ZoneSvartalvheim { get; set; }

    public EffectsList EffectsList { get; private set; }

    public override void Initialize()
    {
        base.Initialize();

        EffectsList = new EffectsList();
    }

    public override void ResetEffects()
    {
        base.ResetEffects();
        
        EffectsList.Clear();
    }
}