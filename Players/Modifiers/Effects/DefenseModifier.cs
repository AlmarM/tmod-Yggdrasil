using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers.Effects;

public class DefenseModifier : IPlayerModifier
{
    public string Description => string.Format(PlayerModifierConfig.DefenseDescription, _defense);

    private int _defense;

    public DefenseModifier(int defense)
    {
        _defense = defense;
    }

    public void Apply(Player player)
    {
        player.statDefense += _defense;
    }
}