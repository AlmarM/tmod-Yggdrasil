using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Yggdrasil.Utils;
using System;

namespace Yggdrasil.Content.Players;

/// <summary>
/// Class that handles all logic regarding runes and runic effects.
/// </summary>
public class RunePlayer : ModPlayer
{
    public int RunePower { get; set; }

    public bool ShowRunePower { get; set; }
    public bool OccultBuff { get; set; }
    public bool OdinsEye { get; set; }

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
        if (OdinsEye && damage > Player.statLife && Main.rand.Next(100) < 10)
        {
            Player.NinjaDodge();
            Player.statLife += (int)Math.Ceiling(Player.statLifeMax2 * (0.2f));
            SoundEngine.PlaySound(SoundID.Item4, Player.position);
            Player.HealEffect((int)Math.Ceiling(Player.statLifeMax2 * (0.2f)));
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
        RunePower = 0;
        ShowRunePower = false;
        OccultBuff = false;
        DodgeChance = 0f;
        InvincibilityBonusTime = 0f;
        PreventAmmoConsumptionChance = 0f;
        ApplyRandomBuffChance = 0f;
        RandomBuffDuration = 0f;
        OdinsEye = false;
}
}