using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Runes;

public abstract class Rune : YggdrasilItem, IRune
{
    private IList<(IRuneEffect, IRuneEffectParameters)> _effects;

    public abstract string Label { get; }

    public abstract RuneTier Tier { get; }

    public abstract string TooltipDescription { get; }

    public virtual int Rarity => ItemRarityID.White;

    public virtual int Value => 200;

    public virtual int RunePower => 1;

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault(GetDisplayName());
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = RuneConfig.MaxRuneStack;
        Item.rare = Rarity;
        Item.value = Value;
    }

    public override void OnCreate(ItemCreationContext context)
    {
        InitializeEffects();
    }

    public override ModItem Clone(Item newEntity)
    {
        var clone = (Rune)base.Clone(newEntity);

        if (_effects == null)
        {
            clone.OnCreate(new InitializationContext());
        }
        else
        {
            clone._effects = new List<(IRuneEffect, IRuneEffectParameters)>(_effects);
        }

        return clone;
    }

    public override void UpdateInventory(Player player)
    {
        if (_effects == null)
        {
            InitializeEffects();
        }

        foreach ((IRuneEffect effect, IRuneEffectParameters parameters) in _effects)
        {
            effect.Apply(player, parameters);
        }

        player.GetModPlayer<RunePlayer>().RunePower += RunePower;
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        if (_effects == null)
        {
            InitializeEffects();
        }

        string runeDescription = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, TooltipDescription);
        tooltips.Add(new TooltipLine(Mod, $"RuneDescription", runeDescription));

        for (var i = 0; i < _effects.Count; i++)
        {
            (IRuneEffect effect, IRuneEffectParameters parameters) effectData = _effects[i];
            string description = effectData.effect.GetDescription(effectData.parameters);

            tooltips.Add(new TooltipLine(Mod, $"RuneEffectDescription_{i}", description));
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

    protected abstract void AddEffects();

    protected void AddEffect(IRuneEffect effect, IRuneEffectParameters parameters)
    {
        _effects.Add((effect, parameters));
    }

    private void InitializeEffects()
    {
        _effects = new List<(IRuneEffect, IRuneEffectParameters)>();

        AddEffects();
    }
}