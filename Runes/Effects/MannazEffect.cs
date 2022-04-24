using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class MannazEffect : RuneEffect<MannazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(damageParameters.DamageBonus);

        return MakeDescription(RuneEffectConfig.MannazEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);

        if (!IsOneEnemyClose(player, damageParameters.Distance))
        {
            return;
        }

        player.GetDamage(DamageClass.Generic) += damageParameters.DamageBonus;
    }

    private static bool IsOneEnemyClose(Entity entity, float distance)
    {
        var foundCloseEnemy = false;
        float distanceSquared = distance * distance;

        for (var i = 0; i < 200; i++)
        {
            NPC npc = Main.npc[i];

            if (!NpcUtils.IsAliveHostileNpc(npc) ||
                Vector2.DistanceSquared(entity.Center, npc.Center) > distanceSquared)
            {
                continue;
            }

            if (foundCloseEnemy)
            {
                return false;
            }

            foundCloseEnemy = true;
        }

        return foundCloseEnemy;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float damageBonus, float distance)
        {
            DamageBonus = damageBonus;
            Distance = distance;
        }

        public float DamageBonus { get; }

        public float Distance { get; }
    }
}