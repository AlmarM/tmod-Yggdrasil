using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace Yggdrasil;

public class TooltipBlockProcessor : ITooltipBlockProcessor
{
    public void Process(List<TooltipLine> tooltips, IList<TooltipBlock> blocks, Mod mod)
    {
        while (blocks.Count > 0)
        {
            IGrouping<int?, TooltipBlock>[] groups = blocks
                .GroupBy(b => b.GetInsertIndex(tooltips), b => b)
                .OrderBy(g => g.Key)
                .ToArray();

            IGrouping<int?, TooltipBlock> nextGroup = groups.FirstOrDefault(g => g.Key != null);
            if (nextGroup?.Key != null)
            {
                IOrderedEnumerable<TooltipBlock> nextBlocks = nextGroup.OrderBy(g => g.Order);
                var previousBlockLength = 0;

                foreach (TooltipBlock block in nextBlocks)
                {
                    IList<TooltipLine> lines = block.GetLines(mod);

                    tooltips.InsertRange(nextGroup.Key.Value + previousBlockLength, lines);
                    blocks.Remove(block);

                    previousBlockLength += lines.Count;
                }
            }
            else
            {
                IOrderedEnumerable<TooltipBlock> lastBlocks = groups[0].OrderBy(g => g.Order);
                foreach (TooltipBlock block in lastBlocks)
                {
                    tooltips.AddRange(block.GetLines(mod));
                    blocks.Remove(block);
                }
            }
        }
    }
}