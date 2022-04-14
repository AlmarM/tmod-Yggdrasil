using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class DodgeChanceModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.DodgeChanceDescription, _dodgeChance);

    private int _dodgeChance;

    public DodgeChanceModifier(int dodgeChance)
    {
        _dodgeChance = dodgeChance;
    }

    public override void Apply(Player player)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		modPlayer.dodgeChance += _dodgeChance;
    }
}