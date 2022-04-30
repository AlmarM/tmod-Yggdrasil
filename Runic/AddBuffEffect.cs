// using Yggdrasil.Content.Players;
// using Yggdrasil.Utils;
//
// namespace Yggdrasil.Runic;
//
// public class AddBuffEffect : RunicEffect
// {
//     public int BuffType { get; }
//
//     public int BuffDuration { get; }
//
//     public bool Additive { get; }
//
//     public float ProcChance { get; }
//
//     public AddBuffEffect(int runePower, int buffType, int buffDuration, bool additive, float procChance)
//         : base(runePower)
//     {
//         BuffType = buffType;
//         BuffDuration = buffDuration;
//         Additive = additive;
//         ProcChance = procChance;
//     }
//
//     protected override string GetDescription()
//     {
//         string description = string.Empty;
//         if (Additive)
//         {
//             description += $"Adds a {TextUtils.GetPercentage(ProcChance)}% chance to "
//         }
//
//         return $"";
//     }
//
//     public static float Apply(AttackSpeedEffect[] effects, RunePlayer runePlayer)
//     {
//         
//     }
// }

