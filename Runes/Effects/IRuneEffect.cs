using Terraria;

namespace Yggdrasil.Runes.Effects;

public interface IRuneEffect
{
    string GetDescription(IRuneEffectParameters effectParameters);

    void Apply(Player player, IRuneEffectParameters effectParameters);
}