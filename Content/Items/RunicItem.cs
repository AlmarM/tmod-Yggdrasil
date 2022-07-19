using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.Utilities;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Items;

public abstract class RunicItem : YggdrasilItem
{
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
        return new List<string>();
    }
}