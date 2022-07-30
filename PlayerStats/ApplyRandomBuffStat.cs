using Terraria;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Utils;

namespace Yggdrasil.PlayerStats;

public class ApplyRandomBuffStat : PlayerStat<ApplyRandomBuffStat.Parameters>, IPlayerOnHitNPCModHook
{
    public int Priority { get; set; }

    public void PlayerOnHitNPC(Player player, Item item, NPC target, int damage, float knockback, bool crit)
    {
        if (Main.rand.NextFloat() > Value.Chance)
        {
            return;
        }

        int duration = TimeUtils.SecondsToTicks(Value.Duration);
        BuffUtils.ApplyRandomDebuff(target, duration);
    }

    public class Parameters
    {
        public float Chance { get; set; }

        public float Duration { get; set; }

        public Parameters()
        {
            Chance = 0f;
            Duration = 0f;
        }

        public Parameters(float chance, float duration)
        {
            Chance = chance;
            Duration = duration;
        }
    }
}