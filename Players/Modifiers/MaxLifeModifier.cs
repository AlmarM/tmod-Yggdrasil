using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

public class MaxLifeModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.MaxLifeDescription, _maxLifeAmount);

    private int _maxLifeAmount;

    public MaxLifeModifier(int maxLifeAmount)
    {
        _maxLifeAmount = maxLifeAmount;
    }

    public override void Apply(Player player)
    {
        player.statLifeMax2 += _maxLifeAmount;
    }
}