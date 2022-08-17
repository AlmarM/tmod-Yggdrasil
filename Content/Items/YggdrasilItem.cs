using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items;

public abstract class YggdrasilItem : ModItem
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    [CloneByReference] private readonly ITooltipBlockProcessor _tooltipBlockProcessor = new TooltipBlockProcessor();

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        _tooltipBlockProcessor.Process(tooltips, CreateTooltipBlocks(), Mod);
    }

    public override void OnCreate(ItemCreationContext context)
    {
        SetupData(Item);
    }

    public override ModItem NewInstance(Item entity)
    {
        var instance = (YggdrasilItem)base.NewInstance(entity);
        instance.SetupData(entity);

        return instance;
    }

    protected virtual void SetupData(Item item)
    {
    }

    protected virtual IList<TooltipBlock> CreateTooltipBlocks()
    {
        return new List<TooltipBlock>();
    }
}