using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

internal class DefenseModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.DefenseDescription, _defense);

    private int _defense;

    public DefenseModifier(int defense)
    {
        _defense = defense;
    }

    public override void Apply(Player player)
    {
        player.statDefense += _defense;
    }
}