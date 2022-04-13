using System;
using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

public class DamageStackModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_damageBonus * 100);
            return MakeDescription(PlayerModifierConfig.DamageStackDescription, percentage, _maxStacks);
        }
    }

    private float _damageBonus;
    private int _maxStacks;

    public DamageStackModifier(float damageBonus, int maxStacks)
    {
        _damageBonus = damageBonus;
        _maxStacks = maxStacks;
    }

    public override void Apply(Player player)
    {
    }
}