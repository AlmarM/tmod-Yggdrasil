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
        RunePlayer runePlayer = GetRunePlayer(player);

        FlatRunicDamageEffect.Apply(GetEffects<FlatRunicDamageEffect>(), runePlayer, ref damage, ref flat);
    }

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        RunePlayer runePlayer = GetRunePlayer(player);

        RunicCritChanceEffect.Apply(GetEffects<RunicCritChanceEffect>(), runePlayer, ref crit);
    }

    public override float UseSpeedMultiplier(Player player)
    {
        RunePlayer runePlayer = GetRunePlayer(player);
        var speed = 1f;

        speed += AttackSpeedEffect.Apply(GetEffects<AttackSpeedEffect>(), runePlayer);

        return speed;
    }

    public override bool? CanAutoReuseItem(Player player)
    {
        RunePlayer runePlayer = GetRunePlayer(player);

        if (AutoReuseEffect.Apply(GetEffects<AutoReuseEffect>(), runePlayer))
        {
            return true;
        }

        return null;
    }

    public override void HoldItem(Player player)
    {
        RunePlayer runePlayer = GetRunePlayer(player);

        FaintLightEffect.Apply(GetEffects<FaintLightEffect>(), runePlayer);

        var size = 1f;

        size += BiggerSizeEffect.Apply(GetEffects<BiggerSizeEffect>(), runePlayer, Item);

        Item.scale = size;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        RunePlayer runePlayer = GetRunePlayer(player);

        InflictBuffEffect.Apply(GetEffects<InflictBuffEffect>(), runePlayer, target);
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