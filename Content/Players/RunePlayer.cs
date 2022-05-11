using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Yggdrasil.Utils;
using System;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Buffs;

namespace Yggdrasil.Content.Players;

/// <summary>
/// Class that handles all logic regarding runes and runic effects.
/// </summary>
public class RunePlayer : ModPlayer
{
    public int RunePower { get; set; }
    
    public bool OccultBuff { get; set; }
    public float DodgeChance { get; set; }
    public float InvincibilityBonusTime { get; set; }
    public float PreventAmmoConsumptionChance { get; set; }
    public float ApplyRandomBuffChance { get; set; }
    public float RandomBuffDuration { get; set; }
    public float SlowDebuffValue { get; set; }

    //Here comes all the equip check for runepower accessories
    public bool SurtrEquip { get; set; }
    public bool ProtectiveSlabEquip { get; set; }
    public bool ArmRingEquip { get; set; }
    public bool DwarvenMedallionEquip { get; set; }
    public bool NorsemanShieldEquip { get; set; }
    public bool RunemasterEmblemEquip { get; set; }
    public bool FrostGiantHandEquip { get; set; }
    public bool OdinsEyeEquip { get; set; }
    public bool HelsNailEquip { get; set; }
    public bool TyrHandEquip { get; set; }
    public bool RunemasterCrestEquip { get; set; }
    public bool NiddhogToothEquip { get; set; }

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
        if (OdinsEyeEquip && damage > Player.statLife && Main.rand.Next(100) < 10)
        {
            var healBack = 0.2f;
            if (RunePower >= 10)
                healBack = 0.5f;

            Player.NinjaDodge();
            Player.statLife += (int)Math.Ceiling(Player.statLifeMax2 * (healBack));
            SoundEngine.PlaySound(SoundID.Item4, Player.position);
            Player.HealEffect((int)Math.Ceiling(Player.statLifeMax2 * (healBack)));
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
        
        if (crit && item.ModItem is RunicItem)
        {
            if (FrostGiantHandEquip && RunePower >=5)
            {
                int projectileCount = 12;

                const float projectileSpeed = 6f;
                const float radius = 25f;

                float delta = MathF.PI * 2 / projectileCount;

                for (var i = 0; i < projectileCount; i++)
                {
                    float theta = delta * i;
                    var position = target.Center + Vector2.One.RotatedBy(theta) * radius;

                    Vector2 direction = position - target.Center;
                    direction = Vector2.Normalize(direction);
                    direction = Vector2.Multiply(direction, projectileSpeed);

                    Projectile.NewProjectile(null, position, direction, ProjectileID.Blizzard, 15, 2, Player.whoAmI);
                }
            }
        }

        if (item.ModItem is RunicItem)
        {
            int poisonTime = 300;
            if (HelsNailEquip)
            {
                if (RunePower >= 4)
                {
                    poisonTime = 480;
                }
                target.AddBuff(BuffID.Poisoned, poisonTime);
            }
        }

        if (item.ModItem is RunicItem && NiddhogToothEquip == true)
        {
            target.AddBuff(ModContent.BuffType<SlowDebuff>(), 180);
            if (RunePower >= 10)
            {
                target.AddBuff(BuffID.Venom, 180);
            }
        }
    }

    public override float UseSpeedMultiplier(Item item)
    {
        var speed = 1f;
        if (item.ModItem is RunicItem && TyrHandEquip == true)
        {
            speed += 0.10f;
        }

        if (item.ModItem is RunicItem && RunemasterCrestEquip == true)
        {
            speed += 0.15f;
        }

        return speed;
    }

    public override bool? CanAutoReuseItem(Item item)
    {
        if (item.ModItem is RunicItem && TyrHandEquip == true)
        {
            return true;
        }
        return null;
    }

    //We check for runic power at the absolute end
    //We make sure these gets activated both with rune and accessories potential +X runicpower
    public override void PostUpdateEquips() 
    {
        if (SurtrEquip)

            if (RunePower >= 6)
            {
                Player.AddBuff(BuffID.Inferno, 2);
            }

        if (ProtectiveSlabEquip)
            if (RunePower >= 15)
            {
                Player.statDefense += 15;
            }

        if (ArmRingEquip)
            if (RunePower >= 2)
            {
                Player.GetDamage<RunicDamageClass>() += 0.01f;
            }
        if (DwarvenMedallionEquip)
            if (RunePower >= 2)
            {
                Player.statDefense += 1;
            }

        if (NorsemanShieldEquip)
            if (RunePower >= 2)
            {
                Player.GetDamage<RunicDamageClass>() += 0.02f;
            }

        if (RunemasterEmblemEquip)
            if (RunePower >= 5)
            {
                Player.GetCritChance<RunicDamageClass>() += 1;
            }

        if (TyrHandEquip)
            if (RunePower >= 4)
            {
                Player.GetDamage<RunicDamageClass>() += 0.05f;
            }

    }

    public override void ResetEffects()
    {
        RunePower = 0;
        OccultBuff = false;
        DodgeChance = 0f;
        InvincibilityBonusTime = 0f;
        PreventAmmoConsumptionChance = 0f;
        ApplyRandomBuffChance = 0f;
        RandomBuffDuration = 0f;
        SlowDebuffValue = 0f;

        //Runepower Accessories equip reset
        SurtrEquip = false;
        ProtectiveSlabEquip = false;
        ArmRingEquip = false;
        DwarvenMedallionEquip = false;
        NorsemanShieldEquip = false;
        RunemasterEmblemEquip = false;
        TyrHandEquip = false;
        OdinsEyeEquip = false;
        FrostGiantHandEquip = false;
        HelsNailEquip = false;
        RunemasterCrestEquip = false;
        NiddhogToothEquip = false;
    }
}