using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Misc;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Players;

public class RunemasterPlayer : ModPlayer
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
    public float RunicProjectileSpeedMultiplier { get; set; }

    public int RunicProjectilesAdd { get; set; }
    public float InsanityHurtValue { get; set; }
    public float SlowDebuffValue { get; set; }

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
        FocusPowerTime = TimeUtils.SecondsToTicks(5);
        FocusThreshold = 10;
        InsanityThreshold = 25;
        InsanityRemoverValue = 10;
        InsanityHurtValue = 0.25f;
        RunicProjectilesAdd = 0;
        RunicProjectileSpeedMultiplier = 10f;
    }

    public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
    {
        return new[]
        {
            new Item(ModContent.ItemType<StartingNote>()),
        };
    }
}