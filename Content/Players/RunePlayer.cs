using System;
using System.Collections.Generic;
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
using Yggdrasil.Content.Projectiles;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;
using Yggdrasil.Content.Items.Others;

namespace Yggdrasil.Content.Players;

/// <summary>
/// Class that handles all logic regarding runes and runic effects.
/// </summary>
public class RunePlayer : ModPlayer
{
    public int RunePower { get; set; }
    public int FocusPowerTime { get; set; }
    public int FocusThreshold { get; set; }
    public int FocusValue { get; set; }
    public int FocusTimer { get; set; }
    public int InsanityThreshold { get; set; }
    public int InsanityValue { get; set; }
    public int InsanityTimer { get; set; }
    public int InsanityRemoverValue { get; set; }

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
    }

    public override void OnHitByNPC(NPC npc, int damage, bool crit)
    {
        if (Player.HasEffect<GlacierHelmet>())
            npc.AddBuff(ModContent.BuffType<SlowDebuff>(), 120);
    }
    

    public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
    {
        if (ApplyRandomBuffChance > 0f && Main.rand.NextFloat() <= ApplyRandomBuffChance)
        {
            int duration = TimeUtils.SecondsToTicks(RandomBuffDuration);
            BuffUtils.ApplyRandomDebuff(target, duration);
        }
        
    }

    public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
    {
        if (crit && proj.ModProjectile is RunicProjectile)
        {
            if (Player.HasEffect<FrostGiantHand>())
            {
                CreateBlizzardExplosionAroundEntity(12, 6f, 25f, target);
            }

            if (Player.HasEffect<OccultHelmet>())
            {
                target.AddBuff(BuffID.Confused, 180);
            }
        }

        if (proj.ModProjectile is RunicProjectile && Player.HasEffect<NidhoggTooth>())
        {
            target.AddBuff(ModContent.BuffType<SlowDebuff>(), 180);
            target.AddBuff(BuffID.Venom, 180);
        }

        if (proj.ModProjectile is RunicProjectile && Player.HasEffect<FreyaNecklace>())
        {
            if (Main.rand.Next(100) < 5)
            {
                Item.NewItem(null, (int)target.position.X, (int)target.position.Y, target.width, target.height, 58);
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

        if (item.ModItem is RunicItem && Player.HasEffect<JomsborgCasque>())
        {
            speed += (float)InsanityValue/100;
        }

        return speed;
    }

    public override bool? CanAutoReuseItem(Item item)
    {
        return null;
    }

    //We check for runic power at the absolute end
    //We make sure these gets activated both with rune and accessories potential +X runicpower
    public override void PostUpdateEquips()
    {

    }

    public override void PreUpdate()
    {
        if (FocusValue > FocusThreshold)
        {
            FocusValue = FocusThreshold;
        }

        if (InsanityValue >= InsanityThreshold)
        {
            Player.Hurt(PlayerDeathReason.ByCustomReason(Player.name + " spat a bit too much"),
                (int)(Player.statLifeMax * .25f), 0);
            InsanityValue = 0;
        }

        if (InsanityValue > 0)
        {
            InsanityTimer++;
            if (InsanityTimer > 60)
            {
                InsanityValue--;
                InsanityTimer = 0;
            }
        }

        if (FocusValue < FocusThreshold)
        {
            FocusTimer++;
            if (FocusTimer > 60)
            {
                FocusValue++;
                FocusTimer = 0;
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
        FocusThreshold = 10;
        InsanityThreshold = 25;
        InsanityRemoverValue = 10;

    }

    public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
    {
        return new[] {
                new Item(ModContent.ItemType<StartingNote>()),

            };
    }

    private void CreateBlizzardExplosionAroundEntity(int projectileCount, float projectileSpeed, float radius,
        Entity entity)
    {
        float delta = MathF.PI * 2 / projectileCount;

        for (var i = 0; i < projectileCount; i++)
        {
            float theta = delta * i;
            var position = entity.Center + Vector2.One.RotatedBy(theta) * radius;

            Vector2 direction = position - entity.Center;
            direction = Vector2.Normalize(direction);
            direction = Vector2.Multiply(direction, projectileSpeed);

            Projectile.NewProjectile(null, position, direction, ProjectileID.Blizzard, 15, 2, Player.whoAmI);
        }
    }
}