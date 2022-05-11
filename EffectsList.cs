using System.Collections.Generic;

namespace Yggdrasil;

public class EffectsList
{
    private readonly HashSet<string> _effectsList;

    public EffectsList()
    {
        _effectsList = new HashSet<string>();
    }

    public bool Has<T>()
    {
        return Has(typeof(T).FullName);
    }

    public bool Has(string key)
    {
        return _effectsList.Contains(key);
    }

    public void Set<T>()
    {
        Set(typeof(T).FullName);
    }

    public void Set(string key)
    {
        _effectsList.Add(key);
    }

    public void Clear()
    {
        _effectsList.Clear();
    }
}