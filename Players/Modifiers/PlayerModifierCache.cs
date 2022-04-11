using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Yggdrasil.Players.Modifiers;

public class PlayerModifierCache
{
    private readonly Dictionary<PlayerModifierType, IPlayerModifier> _cachedModifiers;

    public PlayerModifierCache()
    {
        _cachedModifiers = new Dictionary<PlayerModifierType, IPlayerModifier>();

        CreateTypeMap();
    }

    public IPlayerModifier Get(PlayerModifierType type)
    {
        return _cachedModifiers[type];
    }

    private void CreateTypeMap()
    {
        var baseType = typeof(IPlayerModifier);

        Assembly assembly = Assembly.GetAssembly(baseType);
        if (assembly == null)
        {
            throw new NullReferenceException($"Assembly for {nameof(IPlayerModifier)} was null.");
        }

        Type[] types = assembly.GetTypes();
        IEnumerable<Type> allModifierTypes = types.Where(IsValidDerivedType);
        foreach (Type type in allModifierTypes)
        {
            var instance = (IPlayerModifier)Activator.CreateInstance(type);
            if (instance == null)
            {
                throw new NullReferenceException($"Activator couldn't create instance for type {type}.");
            }

            _cachedModifiers.Add(instance.Type, instance);
        }

        bool IsValidDerivedType(Type type) => type.IsClass && !type.IsAbstract && type.IsAssignableTo(baseType) && !type.IsInterface;
    }
}