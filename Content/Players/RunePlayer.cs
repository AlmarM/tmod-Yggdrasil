using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Players;

internal class RunePlayer : ModPlayer
{
    public float DodgeChance { get; set; }

    public float InvincibilityBonusTime { get; set; }

    public float PreventAmmoConsumptionChance { get; set; }

    public float ApplyRandomBuffChance { get; set; }

    public float RandomBuffDuration { get; set; }

    public override bool CanConsumeAmmo(Item weapon, Item ammo)
    {
        if (PreventAmmoConsumptionChance > 0f && Main.rand.NextFloat() <= PreventAmmoConsumptionChance)
        {
            return false;
        }

        return true;
    }

    public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        if (damage > 0 && DodgeChance > 0f && Main.rand.NextFloat() <= DodgeChance)
        {
            Player.NinjaDodge();
            return false;
        }

        return true;
    }

    public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
    {
        if (InvincibilityBonusTime > 0)
        {
            int bonusTicks = TimeUtils.SecondsToTicks(InvincibilityBonusTime);
            Player.immuneTime += bonusTicks;
        }
    }

    public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
    {
        if (ApplyRandomBuffChance > 0f && Main.rand.NextFloat() <= ApplyRandomBuffChance)
        {
            int duration = TimeUtils.SecondsToTicks(RandomBuffDuration);
            BuffUtils.ApplyRandomDebuff(target, duration);
        }
    }

    public override void ResetEffects()
    {
        DodgeChance = 0f;
        InvincibilityBonusTime = 0f;
        PreventAmmoConsumptionChance = 0f;
        ApplyRandomBuffChance = 0f;
        RandomBuffDuration = 0f;
    }
}