using System.Collections.Generic;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items;

public abstract class YggdrasilItem : ModItem
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    private readonly ITooltipBlockProcessor _tooltipBlockProcessor;

    protected YggdrasilItem()
    {
        _tooltipBlockProcessor = new TooltipBlockProcessor();
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        _tooltipBlockProcessor.Process(tooltips, CreateTooltipBlocks(), Mod);
    }

    protected virtual IList<TooltipBlock> CreateTooltipBlocks()
    {
        return new List<TooltipBlock>();
    }
}