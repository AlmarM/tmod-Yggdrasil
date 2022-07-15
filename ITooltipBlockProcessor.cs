using System.Collections.Generic;
using Terraria.ModLoader;

namespace Yggdrasil;

public interface ITooltipBlockProcessor
{
    void Process(List<TooltipLine> tooltips, IList<TooltipBlock> blocks, Mod mod);
}