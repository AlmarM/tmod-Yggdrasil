using System;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

internal class DamageStackOnKillsModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_damageBonus * 100);
            return MakeDescription(PlayerModifierConfig.DamageStackOnKillsDescription, percentage, _maxStacks);
        }
    }

    private float _damageBonus;
    private int _maxStacks;

    public DamageStackOnKillsModifier(float damageBonus, int maxStacks)
    {
        _damageBonus = damageBonus;
        _maxStacks = maxStacks;
    }

    public override void Apply(Player player)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        float totalDamageBonus = _damageBonus * Math.Min(runePlayer.ConsecutiveKills, _maxStacks);

        player.GetDamage(DamageClass.Magic) += totalDamageBonus;
        player.GetDamage(DamageClass.Melee) += totalDamageBonus;
        player.GetDamage(DamageClass.Ranged) += totalDamageBonus;
        player.GetDamage(DamageClass.Summon) += totalDamageBonus;
        player.GetDamage(DamageClass.Throwing) += totalDamageBonus;
    }
}