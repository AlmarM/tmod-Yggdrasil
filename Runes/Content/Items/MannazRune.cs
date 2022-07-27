using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class MannazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Mannaz;

    protected abstract float DamageBonus { get; }
    
    protected abstract float Distance { get; }

    protected override void OnUpdateInventory(Player player)
    {
        if (!IsOneEnemyClose(player, Distance))
        {
            return;
        }

        player.GetDamage(DamageClass.Generic) += DamageBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var damagePercentage = TextUtils.GetPercentage(DamageBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, damagePercentage));
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

}