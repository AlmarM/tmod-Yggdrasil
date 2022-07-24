using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Yggdrasil.ModHooks.Player;

public abstract class ModHookPlayer : ModPlayer
{
    private IDictionary<Type, IList<IPlayerModHook>> _modHookMap;

    public override void Initialize()
    {
        InitializeModHookMap();
    }

    public override void OnHitByNPC(NPC npc, int damage, bool crit)
    {
        IEnumerable<IPlayerOnHitByNPCModHook> hooks = GetModHooks<IPlayerOnHitByNPCModHook>();
        hooks = hooks.OrderBy(h => h.Priority);

        foreach (IPlayerOnHitByNPCModHook hook in hooks)
        {
            hook.OnHitByNPC(Player, npc, damage, crit);
        }
    }

    public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
    {
        IEnumerable<IPlayerOnHitNPCWithProjModHook> hooks = GetModHooks<IPlayerOnHitNPCWithProjModHook>();
        hooks = hooks.OrderBy(h => h.Priority);

        foreach (IPlayerOnHitNPCWithProjModHook hook in hooks)
        {
            hook.OnPlayerHitNPCWithProj(Player, proj, target, damage, knockback, crit);
        }
    }

    public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        IEnumerable<IPlayerPreHurtModHook> hooks = GetModHooks<IPlayerPreHurtModHook>();
        hooks = hooks.OrderBy(h => h.Priority);

        foreach (IPlayerPreHurtModHook hook in hooks)
        {
            if (!hook.PreHurt(Player, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage,
                    ref playSound, ref genGore, ref damageSource))
            {
                return false;
            }
        }

        return true;
    }

    public override float UseSpeedMultiplier(Item item)
    {
        IEnumerable<IPlayerUseSpeedMultiplierModHook> hooks = GetModHooks<IPlayerUseSpeedMultiplierModHook>();
        hooks = hooks.OrderBy(h => h.Priority);

        float speedMultiplier = base.UseSpeedMultiplier(item);

        foreach (IPlayerUseSpeedMultiplierModHook hook in hooks)
        {
            hook.PlayerUseSpeedMultiplier(Player, item, ref speedMultiplier);
        }

        return speedMultiplier;
    }

    public override void ResetEffects()
    {
        foreach (Type key in _modHookMap.Keys)
        {
            _modHookMap[key].Clear();
        }
    }

    public void AddModHooks(IPlayerModHook hooks)
    {
        Type baseType = typeof(IPlayerModHook);
        Type[] hookTypes = hooks
            .GetType()
            .GetInterfaces()
            .Where(i => baseType.IsAssignableFrom(i) && i != baseType)
            .ToArray();

        foreach (Type type in hookTypes)
        {
            _modHookMap[type].Add(hooks);
        }
    }

    private void InitializeModHookMap()
    {
        _modHookMap = new Dictionary<Type, IList<IPlayerModHook>>();

        Type baseType = typeof(IPlayerModHook);
        Type[] hookTypes = baseType.Assembly
            .GetTypes()
            .Where(t => baseType.IsAssignableFrom(t) && t != baseType && t.IsInterface)
            .ToArray();

        foreach (Type type in hookTypes)
        {
            _modHookMap.Add(type, new List<IPlayerModHook>());
        }
    }

    private IEnumerable<T> GetModHooks<T>() where T : IPlayerModHook
    {
        var type = typeof(T);
        return _modHookMap[type].Cast<T>();
    }
}