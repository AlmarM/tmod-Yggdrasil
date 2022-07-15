using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes;

public abstract class Rune : YggdrasilItem
{
    protected abstract RuneTooltipText TooltipText { get; }

    protected string ItemName => TooltipText.Name;

    protected string ItemDescription => FormatRuneTier(TooltipText.DescriptionFormat, Tier, true);

    protected abstract RuneTier Tier { get; }

    protected virtual int RunePower => 1;

    protected virtual int Rarity => ItemRarityID.White;

    protected virtual int Value => Terraria.Item.sellPrice(silver: 2);

    public override void SetStaticDefaults()
    {
        string fullItemName = FormatRuneTier($"{{0}}{ItemName} Rune", Tier);

        DisplayName.SetDefault(fullItemName);
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = 1;
    }

    protected override IList<TooltipBlock> CreateTooltipBlocks()
    {
        var descriptionBlock = new TooltipBlock(RuneTooltipName.RuneDescription);
        descriptionBlock.AddLine(TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, ItemDescription));

        var effectBlock = new TooltipBlock(RuneTooltipName.RuneEffectDescriptions, 1);
        effectBlock.AddLine(FormatRuneTier(TooltipText.EffectDescriptionFormat, Tier));

        return new List<TooltipBlock>
        {
            descriptionBlock,
            effectBlock,
        };
    }

    /// <summary>
    /// Insert the display name for a given tier into the string format. It will add an extra space at the end
    /// if the display name isn't empty. Examples:
    /// {0}Rune with RuneTier.Minor => Minor Rune
    /// {0}Rune with RuneTier.Normal => Rune
    /// A {0}Rune with RuneTier.Major => A Major Rune
    /// </summary>
    protected static string FormatRuneTier(string format, RuneTier tier, bool forceLowerCase = false)
    {
        string tierName = tier.GetDisplayName();

        if (!string.IsNullOrEmpty(tierName))
        {
            if (forceLowerCase)
            {
                tierName = tierName.ToLowerInvariant();
            }

            tierName += " ";
        }

        return string.Format(format, tierName);
    }
}