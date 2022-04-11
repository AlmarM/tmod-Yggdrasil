using System.Collections.Generic;
using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Extensions;
using Yggdrasil.Players.Modifiers;
using Yggdrasil.Utils;

namespace Yggdrasil.Items.Runes;

public abstract class Rune : YggdrasilItem, IRune
{
    public abstract string RuneName { get; }

    public abstract RuneTier Tier { get; }

    public abstract string TooltipDescription { get; }

    private readonly ICollection<(PlayerModifierType, int)> _modifiers;

    protected Rune()
    {
        _modifiers = new List<(PlayerModifierType, int)>();
    }

    public override void SetStaticDefaults()
    {
        SetModifiers();

        DisplayName.SetDefault(GetDisplayName());
        Tooltip.SetDefault(GetTooltipDescription());
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = RuneConfig.MaxRuneStack;
    }

    public override void UpdateInventory(Player player)
    {
        foreach ((PlayerModifierType type, int amount) in _modifiers)
        {
            IPlayerModifier modifier = Instances.PlayerModifierCache.Get(type);
            modifier.Update(player, amount);
        }
    }

    protected virtual string GetDisplayName()
    {
        string prefix = Tier.GetDisplayName();

        if (!string.IsNullOrEmpty(prefix))
        {
            prefix += " ";
        }

        return $"{prefix}{RuneName} Rune";
    }

    protected virtual string GetTooltipDescription()
    {
        string description = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, TooltipDescription);

        foreach ((PlayerModifierType type, int amount) in _modifiers)
        {
            description += $"\n{PlayerModifierUtils.GetDescription(type, amount)}";
        }

        return description;
    }

    protected abstract void SetModifiers();

    protected void AddModifier(PlayerModifierType type, int amount)
    {
        _modifiers.Add((type, amount));
    }
}