using Terraria;

namespace Yggdrasil.Utils;

public static class NpcUtils
{
    public static bool IsAliveHostileNpc(NPC npc)
    {
        return npc.active && npc.lifeMax > 5 && !npc.dontTakeDamage && !npc.friendly && !npc.immortal;
    }
}