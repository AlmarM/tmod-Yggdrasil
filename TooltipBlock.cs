using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Yggdrasil;

public class TooltipBlock
{
    public string Name { get; }

    public int Order { get; }

    private readonly List<string> _lines = new();
    private string _indexSeparator = "_";
    private Func<List<TooltipLine>, int?> _insertIndexFunc;

    public int LineCount => _lines.Count;

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

    public void AddLines(IEnumerable<string> lines)
    {
        _lines.AddRange(lines);
    }

    public void SetIndexSeparator(string separator)
    {
        _indexSeparator = separator;
    }

    public void SetInsertIndexFunc(Func<List<TooltipLine>, int?> func)
    {
        _insertIndexFunc = func;
    }

    public int? GetInsertIndex(List<TooltipLine> tooltips)
    {
        return _insertIndexFunc?.Invoke(tooltips);
    }

    public IList<TooltipLine> GetLines(Mod mod)
    {
        var output = new List<TooltipLine>();

        if (_lines.Count == 1)
        {
            output.Add(new TooltipLine(mod, $"{Name}", _lines[0]));
        }
        else
        {
            for (var i = 0; i < _lines.Count; i++)
            {
                var finalName = $"{Name}{_indexSeparator}{i}";
                output.Add(new TooltipLine(mod, finalName, _lines[i]));
            }
        }

        return output;
    }
}