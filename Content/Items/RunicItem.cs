using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items;

public abstract class RunicItem : YggdrasilItem
{
    private IList<IRunicEffect> _runicEffects;

    // public override void SetStaticDefaults()
    // {
    //     Tooltip.SetDefault(GetTooltip());
    // }

    public override void OnCreate(ItemCreationContext context)
    {
        _runicEffects = new List<IRunicEffect>();

        AddEffects();

        _runicEffects = _runicEffects.OrderBy(re => re.RunePowerRequired).ToList();
    }

    public override ModItem Clone(Item newEntity)
    {
        var clone = (RunicItem)base.Clone(newEntity);

        if (_runicEffects == null)
        {
            clone.OnCreate(new InitializationContext());
        }
        else
        {
            clone._runicEffects = new List<IRunicEffect>(_runicEffects);
        }

        return clone;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        RunePlayer runePlayer = GetRunePlayer(player);

        FlatRunicDamageEffect.Apply(GetEffects<FlatRunicDamageEffect>(), runePlayer, ref damage);
    }

    public override void ModifyWeaponCrit(Player player, ref float crit)
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

        runePlayer.HitCount++;

        //THIS IS GOOD FOR TESTING BUT TURN THIS ON FOR REALEASE AND REMOVE THE HITCOUNT++ ABOVE. 
        //if (target.type != NPCID.TargetDummy)
        //{
        //    runePlayer.HitCount++;
        //}

        InflictBuffEffect.Apply(GetEffects<InflictBuffEffect>(), runePlayer, target);
    }

    public override int ChoosePrefix(UnifiedRandom rand)
    {
        int[] allowedPrefixes = RuneConfig.AllowedRunicVanillaPrefixes;
        int prefixIndex = rand.Next(allowedPrefixes.Length);

        return allowedPrefixes[prefixIndex];
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        // Class title additions
        int lineIndex = tooltips.FindIndex(x => x.Name == "ItemName" && x.Mod == "Terraria");
        if (lineIndex >= 0)
        {
            string title = RuneConfig.ColoredRunemasterTitleLabel;
            tooltips.Insert(lineIndex + 1, new TooltipLine(Mod, "ClassTitle", title));
        }

        List<string> runicDescriptions = GetRunicEffectDescriptions();
        for (var i = 0; i < runicDescriptions.Count; i++)
        {
            string description = runicDescriptions[i];
            tooltips.Add(new TooltipLine(Mod, $"RunicEffectDescription_{i}", description));
        }
    }

    protected virtual List<string> GetRunicEffectDescriptions()
    {
        var lines = new List<string>();

        foreach (IRunicEffect effect in _runicEffects)
        {
            lines.Add(effect.Description);
        }

        return lines;
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