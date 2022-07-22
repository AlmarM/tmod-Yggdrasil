using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Armor;
using Yggdrasil.Content.Items.Armor.Nordic;
using Yggdrasil.Content.Items.Others;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Projectiles.Magic;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster.Content.Items;

namespace Yggdrasil.Content.Players;

public class RunemasterPlayer : YggdrasilPlayer
{
    public int RunePower { get; set; }
    public int FocusPowerTime { get; set; }
    public int FocusThreshold { get; set; }
    public int Focus { get; set; }
    public int FocusTimer { get; set; }
    public int InsanityThreshold { get; set; }
    public int Insanity { get; set; }
    public int InsanityTimer { get; set; }
    public int InsanityRemoverValue { get; set; }
    public int RunicProjectilesAdd { get; set; }
    public float InsanityHurtValue { get; set; }
    public float SlowDebuffValue { get; set; }
    public float RunicProjectileSpeedMultiplyer { get; set; }

    public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        if (Player.HasEffect<OdinsEye>() && damage > Player.statLife && Main.rand.Next(100) < 10)
        {
            var healBack = 0.2f;

            Player.statLife += (int)Math.Ceiling(Player.statLifeMax2 * healBack);

            Player.NinjaDodge();
            Player.HealEffect((int)Math.Ceiling(Player.statLifeMax2 * (healBack)));

            SoundEngine.PlaySound(SoundID.Item4, Player.position);

            return false;
        }

        if (Player.HasEffect<RunemasterShield>() && damage > Player.statLife && Main.rand.Next(100) < 25)
        {
            var healBack = 0.5f;

            Player.statLife += (int)Math.Ceiling(Player.statLifeMax2 * healBack);

            Player.NinjaDodge();
            Player.HealEffect((int)Math.Ceiling(Player.statLifeMax2 * (healBack)));

            SoundEngine.PlaySound(SoundID.Item4, Player.position);

            return false;
        }

        return true;
    }

    public override void OnHitByNPC(NPC npc, int damage, bool crit)
    {
        if (Player.HasEffect<GlacierHelmet>() || Player.HasEffect<NordicHaume>())
            npc.AddBuff(ModContent.BuffType<SlowDebuff>(), 120);
    }

    public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
    {
        if (crit && proj.ModProjectile is RunicProjectile)
        {
            if (Player.HasEffect<FrostGiantHand>())
            {
                CreateBlizzardExplosionAroundEntity(5, 6f, 25f, target);
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

        if (proj.ModProjectile is RunicProjectile && Player.HasEffect<FreyaNecklace>() &&
            target.type != NPCID.TargetDummy)
        {
            if (Main.rand.Next(100) < 1)
            {
                Item.NewItem(null, (int)target.position.X, (int)target.position.Y, target.width, target.height, 58);
            }
        }
    }

    public override float UseSpeedMultiplier(Item item)
    {
        var speed = 1f;
        if (item.ModItem is RuneTablet && Player.HasEffect<TyrHand>())
        {
            speed += 0.1f;
        }

        if (item.ModItem is RuneTablet && Player.HasEffect<RunemasterCrest>())
        {
            speed += 0.15f;
        }

        if (item.ModItem is RuneTablet && Player.HasEffect<BerserkerBoots>())
        {
            speed += 0.1f;
        }

        if (item.ModItem is RuneTablet && Player.HasEffect<JomsborgCasque>())
        {
            speed += (float)Insanity / 100;
        }

        if (item.ModItem is RuneTablet && Player.HasEffect<TheSunBuff>())
        {
            speed += 0.1f;
        }

        return speed;
    }

    //We check for runic power at the absolute end
    //We make sure these gets activated both with rune and accessories potential +X runicpower
    public override void PostUpdateEquips()
    {
    }

    public override void PreUpdate()
    {
        if (Focus > FocusThreshold)
        {
            Focus = FocusThreshold;
        }

        if (Insanity >= InsanityThreshold)
        {
            int diff = (int)(Player.statLifeMax2 * InsanityHurtValue);
            Player.statLife -= diff;
            CombatText.NewText(Player.Hitbox, CombatText.DamagedFriendly, diff);
            Player.immuneNoBlink = false;
            Player.immune = true;
            Player.immuneTime = 20;


            SoundEngine.PlaySound(SoundID.PlayerHit, Player.position);


            //Player.Hurt(PlayerDeathReason.ByCustomReason(Player.name + " went insane"),
            //    (int)(Player.statLifeMax * InsanityHurtValue), 0);
            Insanity = 0;
        }

        if (Insanity > 0)
        {
            InsanityTimer++;
            if (InsanityTimer > 60)
            {
                Insanity--;
                InsanityTimer = 0;
            }
        }

        if (Focus < FocusThreshold)
        {
            FocusTimer++;
            if (FocusTimer > 60)
            {
                Focus++;
                FocusTimer = 0;
            }
        }
    }

    public override void ResetEffects()
    {
        RunePower = 0;
        SlowDebuffValue = 0f;
        FocusPowerTime = 300; //60 = 1sec
        FocusThreshold = 10;
        InsanityThreshold = 25;
        InsanityRemoverValue = 10;
        InsanityHurtValue = 0.25f;
        RunicProjectilesAdd = 0;
        RunicProjectileSpeedMultiplyer = 10f;
    }

    public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
    {
        return new[]
        {
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

            Projectile.NewProjectile(null, position, direction, ModContent.ProjectileType<GlacierStaffProjectile>(), 15,
                2, Player.whoAmI);
        }
    }
}