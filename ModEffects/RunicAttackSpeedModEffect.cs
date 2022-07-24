using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Runemaster.Content.Items;
using Yggdrasil.Utils;

namespace Yggdrasil.ModEffects;

public class RunicAttackSpeedModEffect : IPlayerUseSpeedMultiplierModHook
{
    public int Priority { get; }

    public string EffectDescription
    {
        get
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string percentage = TextUtils.GetPercentage(_multiplier);

            return $"{percentage}% increased {runicText} attack speed";
        }
    }

    private readonly float _multiplier;

    public RunicAttackSpeedModEffect(float multiplier)
    {
        _multiplier = multiplier;
    }

    public void PlayerUseSpeedMultiplier(Player player, Item item, ref float currentMultiplier)
    {
        if (item.ModItem is not RuneTablet)
        {
            return;
        }

        currentMultiplier += _multiplier;
    }
}