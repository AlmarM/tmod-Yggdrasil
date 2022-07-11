using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Yggdrasil;

public class TooltipBlock
{
    public string Name { get; }

    public int Order { get; }

    private IList<string> _lines = new List<string>();
    private string _indexSeparator = "_";

    public TooltipBlock(Enum type, int order = 0)
    {
        Name = type.ToString();
        Order = order;
    }

    public TooltipBlock(string name, int order = 0)
    {
        Name = name;
        Order = order;
    }

    public void AddLine(string line)
    {
        _lines.Add(line);
    }

    public void SetIndexSeparator(string separator)
    {
        _indexSeparator = separator;
    }

    public IList<TooltipLine> GetLines(Mod mod)
    {
        var output = new List<TooltipLine>();

        for (int i = 0; i < _lines.Count; i++)
        {
            var finalName = $"{Name}{_indexSeparator}{i}";
            output.Add(new TooltipLine(mod, finalName, _lines[i]));
        }

        return output;
    }
}