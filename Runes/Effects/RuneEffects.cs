using System;
using System.Collections.Generic;

namespace Yggdrasil.Runes.Effects;

public static class RuneEffects
{
    private static IDictionary<Type, IRuneEffect> _effectCache;

    public static T Get<T>(bool newInstance = false) where T : IRuneEffect, new()
    {
        if (_effectCache == null)
        {
            Initialize();
        }

        if (newInstance)
        {
            return new T();
        }

        Type type = typeof(T);
        if (!_effectCache.ContainsKey(type))
        {
            _effectCache.Add(type, new T());
        }

        return (T)_effectCache[type];
    }

    public static void Initialize()
    {
        _effectCache = new Dictionary<Type, IRuneEffect>();
    }

    public static void Dispose()
    {
        _effectCache?.Clear();
        _effectCache = null;
    }
}