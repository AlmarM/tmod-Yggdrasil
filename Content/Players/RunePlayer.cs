using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Armor;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Players;

/// <summary>
/// Class that handles all logic regarding runes and runic effects.
/// </summary>
public class RunePlayer : ModPlayer
{
    public int RunePower { get; set; }
    public int HitCount { get; set; }
    public int FocusPowerTime { get; set; }
    public int FartThreshold { get; set; }
    public int FartValue { get; set; }
    public int FartTimer { get; set; }
    public int PukeThreshold { get; set; }
    public int PukeValue { get; set; }
    public int PukeTimer { get; set; }

    public float DodgeChance { get; set; }
    public float InvincibilityBonusTime { get; set; }
    public float PreventAmmoConsumptionChance { get; set; }
    public float ApplyRandomBuffChance { get; set; }
    public float RandomBuffDuration { get; set; }
    public float SlowDebuffValue { get; set; }

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

        if (Player.HasEffect<OdinsEye>() && damage > Player.statLife && Main.rand.Next(100) < 10)
        {
            var healBack = 0.2f;
            if (RunePower >= 10)
            {
                healBack = 0.5f;
            }

            Player.statLife += (int)Math.Ceiling(Player.statLifeMax2 * healBack);

            Player.NinjaDodge();
            Player.HealEffect((int)Math.Ceiling(Player.statLifeMax2 * (healBack)));

            SoundEngine.PlaySound(SoundID.Item4, Player.position);

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

        HitCount = 0;
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
            if (Player.HasEffect<FrostGiantHand>() && RunePower >= 5)
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

            if (Player.HasEffect<OccultHelmet>())
            {
                target.AddBuff(BuffID.Confused, 180);
            }
        }

        if (item.ModItem is RunicItem)
        {
            if (Player.HasEffect<HelsNail>() && RunePower >= 4)
            {
                target.AddBuff(BuffID.Poisoned, TimeUtils.SecondsToTicks(8));
            }
        }

        if (item.ModItem is RunicItem && Player.HasEffect<NidhoggTooth>())
        {
            target.AddBuff(ModContent.BuffType<SlowDebuff>(), 180);

            if (RunePower >= 10)
            {
                target.AddBuff(BuffID.Venom, 180);
            }
        }

        if (item.ModItem is RunicItem && Player.HasEffect<FreyaNecklace>())
        {
            if (Main.rand.Next(100) < 5)
            {
                Item.NewItem(null, (int)target.position.X, (int)target.position.Y, target.width, target.height, 58);
            }
        }

        if (item.ModItem is RunicItem && Player.HasEffect<BloodyBuff>())
        {
            if (Main.rand.Next(100) < 4)
            {
                Item.NewItem(null, (int)target.position.X, (int)target.position.Y, target.width, target.height, 58);
            }
        }

        if (item.ModItem is RunicItem && Player.HasEffect<BeeSmashBuff>())
        {
            if (Player.statLife != Player.statLifeMax2)
            {
                Player.statLife += 2;
                Player.HealEffect(2);
            }
        }
    }

    public override float UseSpeedMultiplier(Item item)
    {
        var speed = 1f;
        if (item.ModItem is RunicItem && Player.HasEffect<TyrHand>())
        {
            speed += 0.1f;
        }

        if (item.ModItem is RunicItem && Player.HasEffect<RunemasterCrest>())
        {
            speed += 0.15f;
        }

        if (item.ModItem is RunicItem && Player.HasEffect<BerserkerBoots>())
        {
            speed += 0.1f;
        }

        if (item.ModItem is RunicItem && Player.HasEffect<CotinBuff>())
        {
            speed += 0.1f;
        }

        if (item.ModItem is RunicItem && Player.HasEffect<MeadowBuff>())
        {
            speed += 0.1f;
        }
        return speed;
    }

    public override bool? CanAutoReuseItem(Item item)
    {
        if (item.ModItem is RunicItem && Player.HasEffect<TyrHand>())
        {
            return true;
        }

        return null;
    }

    //We check for runic power at the absolute end
    //We make sure these gets activated both with rune and accessories potential +X runicpower
    public override void PostUpdateEquips()
    {
        if (Player.HasEffect<SurtrBelt>() && RunePower >= 6)
        {
            Player.AddBuff(BuffID.Inferno, 2);
        }

        if (Player.HasEffect<ProtectiveRuneSlab>() && RunePower >= 15)
        {
            Player.statDefense += 15;
        }

        if (Player.HasEffect<ArmRing>() && RunePower >= 2)
        {
            Player.GetDamage<RunicDamageClass>() += 0.01f;
        }

        if (Player.HasEffect<DwarvenMedallion>() && RunePower >= 2)
        {
            Player.statDefense += 1;
        }

        if (Player.HasEffect<NorsemanShield>() && RunePower >= 2)
        {
            Player.GetDamage<RunicDamageClass>() += 0.02f;
        }

        if (Player.HasEffect<RunemasterEmblem>() && RunePower >= 5)
        {
            Player.GetCritChance<RunicDamageClass>() += 1;
        }

        if (Player.HasEffect<BerserkerRing>() && RunePower >= 3)
        {
            Player.GetCritChance<RunicDamageClass>() += 1;
        }

        if (Player.HasEffect<RunicNecklace>() && RunePower >= 5)
        {
            Lighting.AddLight((int)Player.Center.X / 16, (int)Player.Center.Y / 16, .5f, .8f, .8f);
        }

        if (Player.HasEffect<AesirWind>() && RunePower >= 2)
        {
            Player.statDefense += 2;
        }

        if (Player.HasEffect<TyrHand>() && RunePower >= 4)
        {
            Player.GetDamage<RunicDamageClass>() += 0.05f;
        }

    }

    public override void PreUpdate()
    {
        

        if (FartValue > FartThreshold)
        {
            FartValue = FartThreshold;
        }

        if (PukeValue >= PukeThreshold)
        {
            Player.Hurt(PlayerDeathReason.ByCustomReason(Player.name + " spat a bit too much"), (int)(Player.statLifeMax * .25f), 0);
            PukeValue = 0;
        }

        if (PukeValue > 0)
        {
            PukeTimer++;
            if (PukeTimer > 60)
            {
                PukeValue--;
                PukeTimer = 0;
            }
        }

        if (FartValue < FartThreshold)
        {
            FartTimer++;
            if (FartTimer > 60)
            {
                FartValue++;
                FartTimer = 0;
            }
        }

    }

    public override void ResetEffects()
    {
        RunePower = 0;
        DodgeChance = 0f;
        InvincibilityBonusTime = 0f;
        PreventAmmoConsumptionChance = 0f;
        ApplyRandomBuffChance = 0f;
        RandomBuffDuration = 0f;
        SlowDebuffValue = 0f;
        FocusPowerTime = 300; //60 = 1sec
        FartThreshold = 10;
        PukeThreshold = 25;
        //FartValue = 0;
        //PukeValue = 0;
    }
}