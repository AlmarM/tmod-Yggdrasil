using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace Yggdrasil.Utils;

public static class BuffUtils
{
    private static readonly int[] AvailableEnemyDebuffs =
    {
        BuffID.Confused,
        BuffID.CursedInferno,
        BuffID.Ichor,
        BuffID.BetsysCurse,
        BuffID.Midas,
        BuffID.Poisoned,
        BuffID.Venom,
        BuffID.OnFire,
        BuffID.Frostburn,
        BuffID.ShadowFlame,
        BuffID.Oiled
    };

    public static void ApplyRandomDebuff(NPC npc, int duration)
    {
        int randomBuff = AvailableEnemyDebuffs[Main.rand.Next(AvailableEnemyDebuffs.Length)];
        npc.AddBuff(randomBuff, duration);
    }
}