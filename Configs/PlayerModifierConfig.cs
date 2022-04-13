namespace Yggdrasil.Configs;

public static class PlayerModifierConfig
{
    /* Descriptions */
    public const string DefenseDescription = "Grant +{0} defense";
    public const string MaxManaDescription = "Grant +{0} mana";
    public const string LifeRegenDescription = "Grant +{0} life regen";
    public const string ManaRegenDescription = "Boost mana regen speed by {0}";

    public const string DamageStackDescription =
        "Grant {0}% damage boost for each consecutive kill." +
        "\nCapped at {1} kills. Getting hit resets the count";
}