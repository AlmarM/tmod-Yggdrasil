using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MeleeSpeedModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_meleeSpeed * 100);
            return MakeDescription(PlayerModifierConfig.MeleeSpeedDescription, percentage, _meleeSpeed);
        }
    }

    private float _meleeSpeed;

    public MeleeSpeedModifier(float meleeSpeed)
    {
        _meleeSpeed = meleeSpeed;
    }

    public override void Apply(Player player)
    {
        player.meleeSpeed += _meleeSpeed;
    }
}