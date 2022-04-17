using Terraria;

namespace Yggdrasil.Runes.Effects;

public abstract class RuneEffect<TParams> : IRuneEffect where TParams : IRuneEffectParameters
{
    public abstract string GetDescription(IRuneEffectParameters effectParameters);

    public abstract void Apply(Player player, IRuneEffectParameters effectParameters);
    protected static TParams CastParameters(IRuneEffectParameters modifierParameters) => (TParams)modifierParameters;

    protected static string MakeDescription(string template, params object[] args) => string.Format(template, args);
}