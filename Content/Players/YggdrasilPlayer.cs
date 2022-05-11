using Terraria.ModLoader;

namespace Yggdrasil.Content.Players;

public class YggdrasilPlayer : ModPlayer
{
    public EffectsList EffectsList { get; private set; }

    public override void Initialize()
    {
        EffectsList = new EffectsList();
    }

    public override void ResetEffects()
    {
        EffectsList.Clear();
    }
}