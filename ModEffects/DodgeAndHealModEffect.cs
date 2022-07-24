using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Utils;

namespace Yggdrasil.ModEffects;

public class DodgeAndHealModEffect : IPlayerPreHurtModHook
{
    public int Priority { get; }

    public string EffectDescription
    {
        get
        {
            string percentage = TextUtils.GetPercentage(_healthRestored);
            return $"Grants {_consequent}% to avoid a fatal blow and heal back to {percentage}% life";
        }
    }

    private int _consequent;
    private float _healthRestored;

    public DodgeAndHealModEffect(int dodgeConsequent, float healthRestored)
    {
        _consequent = dodgeConsequent;
        _healthRestored = healthRestored;
    }

    public bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        if (damage < player.statLife || !Main.rand.NextBool(_consequent))
        {
            return true;
        }

        var healthRestored = (int)Math.Ceiling(player.statLifeMax2 * _healthRestored);

        player.statLife += healthRestored;
        player.HealEffect(healthRestored);
        player.NinjaDodge();

        SoundEngine.PlaySound(SoundID.Item4, player.position);

        return false;
    }
}