using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Content.Players;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items;

public abstract class RunicItem : YggdrasilItem
{
    private IList<IRunicEffect> _runicEffects;

    public override void SetStaticDefaults()
    {
        _runicEffects = new List<IRunicEffect>();

        AddEffects();

        _runicEffects = _runicEffects.OrderBy(re => re.RunePowerRequired).ToList();

        Tooltip.SetDefault(GetTooltip());
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var flatDamageEffects = GetEffects<FlatRunicDamageEffect>();
        RunePlayer runePlayer = GetRunePlayer(player);

        foreach (FlatRunicDamageEffect effect in flatDamageEffects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                flat += effect.FlatDamage;
            }
        }
    }

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var critChanceEffects = GetEffects<RunicCritChanceEffect>();
        RunePlayer runePlayer = GetRunePlayer(player);

        foreach (RunicCritChanceEffect effect in critChanceEffects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                crit += effect.CritBonus;
            }
        }
    }

    public override float UseSpeedMultiplier(Player player)
    {
        var speedBonus = 1f;
        var attackSpeedEffects = GetEffects<AttackSpeedEffect>();
        RunePlayer runePlayer = GetRunePlayer(player);

        foreach (AttackSpeedEffect effect in attackSpeedEffects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                speedBonus += effect.SpeedBonus;
            }
        }

        return speedBonus;
    }


    protected virtual string GetTooltip()
    {
        var tooltip = string.Empty;
        for (var i = 0; i < _runicEffects.Count; i++)
        {
            IRunicEffect effect = _runicEffects[i];
            tooltip += effect.Description;

            if (i < _runicEffects.Count - 1)
            {
                tooltip += "\n";
            }
        }

        return tooltip;
    }

    protected void AddEffect(IRunicEffect effect)
    {
        _runicEffects.Add(effect);
    }

    protected virtual void AddEffects()
    {
    }

    protected RunePlayer GetRunePlayer(Player player)
    {
        return player.GetModPlayer<RunePlayer>();
    }

    protected T[] GetEffects<T>() where T : IRunicEffect
    {
        return _runicEffects.OfType<T>().ToArray();
    }
}