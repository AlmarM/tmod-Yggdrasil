using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class AggroModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.AggroDescription, _aggroAmount);

    private int _aggroAmount;

    public AggroModifier(int aggroAmount)
    {
        _aggroAmount = aggroAmount;
    }

    public override void Apply(Player player)
    {
        player.aggro += _aggroAmount;
    }
}