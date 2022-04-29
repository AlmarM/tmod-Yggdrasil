using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runic;

public abstract class RunicEffect : IRunicEffect
{
    public int RunePowerRequired { get; }

    public string Description
    {
        get
        {
            var runePower = string.Format(RuneConfig.RunePowerLabel, RunePowerRequired);
            var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

            return $"{runePowerColored}: {GetDescription()}";
        }
    }

    protected RunicEffect(int runePower)
    {
        RunePowerRequired = runePower;
    }

    protected abstract string GetDescription();
}