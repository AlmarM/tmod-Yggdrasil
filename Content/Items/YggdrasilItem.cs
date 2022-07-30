using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items;

public abstract class YggdrasilItem : ModItem
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    private ITooltipBlockProcessor _tooltipBlockProcessor;

    public override void OnCreate(ItemCreationContext context)
    {
        _tooltipBlockProcessor = new TooltipBlockProcessor();
    }

    public override ModItem Clone(Item newEntity)
    {
        var clone = (YggdrasilItem)base.Clone(newEntity);
        clone.OnCreate(new InitializationContext());

        return clone;
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