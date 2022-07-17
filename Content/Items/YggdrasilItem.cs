using System.Collections.Generic;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items;

public abstract class YggdrasilItem : ModItem
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    protected bool CacheTooltips { get; set; } = true;

    protected bool ForceUpdateTooltips { get; set; }

    private readonly ITooltipBlockProcessor _tooltipBlockProcessor;
    private List<TooltipLine> _cachedTooltips;

    protected YggdrasilItem()
    {
        _tooltipBlockProcessor = new TooltipBlockProcessor();
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        if (CacheTooltips && !ForceUpdateTooltips && _cachedTooltips?.Count > 0)
        {
            tooltips.Clear();
            tooltips.AddRange(_cachedTooltips);

            return;
        }

        _tooltipBlockProcessor.Process(tooltips, CreateTooltipBlocks(), Mod);

        if (CacheTooltips)
        {
            _cachedTooltips = new List<TooltipLine>(tooltips);
        }

        ForceUpdateTooltips = false;
    }

    protected virtual IList<TooltipBlock> CreateTooltipBlocks()
    {
        return new List<TooltipBlock>();
    }
}