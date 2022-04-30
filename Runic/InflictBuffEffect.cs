using System.Collections.Generic;
using Terraria;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runic;

public class InflictBuffEffect : RunicEffect
{
    public int BuffType { get; }

    public float BuffDuration { get; }

    public string BuffName { get; }

    public bool Additive { get; }

    public float ProcChance { get; }

    public InflictBuffEffect(int runePower,
        int buffType,
        float buffDuration,
        string buffName,
        float procChance,
        bool additive = false)
        : base(runePower)
    {
        BuffType = buffType;
        BuffDuration = buffDuration;
        BuffName = buffName;
        Additive = additive;
        ProcChance = procChance;
    }

    protected override string GetDescription()
    {
        string percentage = TextUtils.GetPercentage(ProcChance);
        var action = Additive ? "Adds" : "Has";

        return $"{action} a {percentage}% chance to inflict {BuffName} for {BuffDuration} seconds.";
    }

    public static void Apply(InflictBuffEffect[] effects, RunePlayer runePlayer, NPC target)
    {
        var buffs = new Dictionary<int, (float, float)>();

        foreach (InflictBuffEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                ProcessEffect(buffs, effect, target);
            }
        }

        InflictAdditiveBuffs(buffs, target);
    }

    private static void ProcessEffect(Dictionary<int, (float, float)> buffs, InflictBuffEffect effect, NPC target)
    {
        if (effect.Additive)
        {
            ProcessAdditiveBuff(buffs, effect);
        }
        else
        {
            InflictBuff(effect.BuffType, effect.BuffDuration, effect.ProcChance, target);
        }
    }

    private static void ProcessAdditiveBuff(Dictionary<int, (float, float)> buffs, InflictBuffEffect effect)
    {
        if (buffs.ContainsKey(effect.BuffType))
        {
            UpdateBuffData(buffs, effect);
        }
        else
        {
            buffs.Add(effect.BuffType, (effect.ProcChance, effect.BuffDuration));
        }
    }

    private static void UpdateBuffData(Dictionary<int, (float, float)> buffs, InflictBuffEffect effect)
    {
        (float procChance, float duration) buffData = buffs[effect.BuffType];
        buffData.procChance += effect.ProcChance;
        buffData.duration += effect.BuffDuration;

        buffs[effect.BuffType] = buffData;
    }

    private static void InflictAdditiveBuffs(Dictionary<int, (float, float)> buffs, NPC target)
    {
        foreach (KeyValuePair<int, (float, float)> kv in buffs)
        {
            (float procChance, float duration) = kv.Value;

            InflictBuff(kv.Key, duration, procChance, target);
        }
    }

    private static void InflictBuff(int buffType, float buffDuration, float procChance, NPC target)
    {
        if (Main.rand.NextFloat() > procChance)
        {
            return;
        }

        int duration = TimeUtils.SecondsToTicks(buffDuration);
        target.AddBuff(buffType, duration);
    }
}