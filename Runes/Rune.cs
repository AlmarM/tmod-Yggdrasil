using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes;

public abstract class Rune : YggdrasilItem
{
    protected abstract RuneTooltipText TooltipText { get; }

    protected string ItemName => TooltipText.Name;

    protected string ItemDescription => RuneUtils.FormatRuneTier(TooltipText.DescriptionFormat, Tier, true);

    protected abstract RuneTier Tier { get; }

    protected virtual int RunePower => 1;

    protected virtual int Rarity => ItemRarityID.White;

    protected virtual int Value => Item.sellPrice(silver: 2);

    public override void SetStaticDefaults()
    {
        string fullItemName = RuneUtils.FormatRuneTier($"{{0}} {ItemName} Rune", Tier);

        DisplayName.SetDefault(fullItemName);
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = 1;
        Item.value = Value;
        Item.rare = Rarity;
    }

    public sealed override void UpdateInventory(Player player)
    {
        Type type = GetType();

        if (player.HasEffect(type))
        {
            return;
        }

        OnUpdateInventory(player);

        player.SetEffect(type);
    }

    protected virtual void OnUpdateInventory(Player player)
    {
    }

    protected override IList<TooltipBlock> CreateTooltipBlocks()
    {
        var descriptionBlock = new TooltipBlock(RuneTooltipName.RuneDescription);
        descriptionBlock.AddLine(TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, ItemDescription));

        var effectBlock = new TooltipBlock(RuneTooltipName.RuneEffectDescriptions, 1);

        ModifyEffectTooltipBlock(effectBlock);

        var blocks = new List<TooltipBlock>
        {
            descriptionBlock
        };

        if (effectBlock.LineCount > 0)
        {
            blocks.Add(effectBlock);
        }

        return blocks;
    }

    protected virtual void ModifyEffectTooltipBlock(TooltipBlock block)
    {
    }
}