using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Extensions;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Runes;

public abstract class Rune : YggdrasilItem, IRune
{
    private readonly ICollection<(IRuneEffect, IRuneEffectParameters)> _effects;

    protected Rune()
    {
        _effects = new List<(IRuneEffect, IRuneEffectParameters)>();
    }

    public abstract string Label { get; }

    public abstract RuneTier Tier { get; }

    public abstract string TooltipDescription { get; }

    public virtual int Rarity => ItemRarityID.White;

    public override void SetStaticDefaults()
    {
        AddEffects();

        DisplayName.SetDefault(GetDisplayName());
        Tooltip.SetDefault(GetTooltipDescription());
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = RuneConfig.MaxRuneStack;
        Item.rare = Rarity;
    }

    public override void UpdateInventory(Player player)
    {
        foreach ((IRuneEffect effect, IRuneEffectParameters parameters) in _effects)
        {
            effect.Apply(player, parameters);
        }
    }

    protected virtual string GetDisplayName()
    {
        string prefix = Tier.GetDisplayName();

        if (!string.IsNullOrEmpty(prefix))
        {
            prefix += " ";
        }

        return $"{prefix}{Label} Rune";
    }

    protected virtual string GetTooltipDescription()
    {
        string description = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, TooltipDescription);

        foreach ((IRuneEffect effect, IRuneEffectParameters parameters) in _effects)
        {
            description += $"\n{effect.GetDescription(parameters)}";
        }

        return description;
    }

    protected abstract void AddEffects();

    protected void AddEffect(IRuneEffect effect, IRuneEffectParameters parameters)
    {
        _effects.Add((effect, parameters));
    }
}