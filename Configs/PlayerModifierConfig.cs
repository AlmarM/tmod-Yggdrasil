namespace Yggdrasil.Configs;

public static class PlayerModifierConfig
{
    /* Descriptions */
    public const string DefenseDescription = "Grant +{0} defense";
    public const string MaxManaDescription = "Increases maximum mana by {0}";
    public const string LifeRegenDescription = "Grant +{0} life regen";
    public const string ManaRegenDescription = "Boost mana regen speed by {0}";
	public const string RangeDamageDescription = "{0}% increased ranged damage";
	public const string MovementSpeedDescription = "{0}% increased movement speed";
	public const string MaximumRunSpeedDescription = "{0}% increased maximum run speed";
	public const string MeleeDamageDescription = "{0}% increased melee damage";
	public const string MagicDamageDescription = "{0}% increased magic damage";
	public const string MinionDamageDescription = "{0}% increased minion damage";
	public const string MaxLifeDescription = "Increases maximum life by {0}";
	public const string CriticalChanceDescription = "{0}% increased critical strike chance";
	public const string DodgeChanceDescription = "{0}% change to dodge the next attack";
	
	public const string AggroDescription = 
		"Enemies are less likely to target you" +
        "\nAggro is decreased by {0}";
	
    public const string DamageStackDescription =
        "Grant {0}% damage boost for each consecutive kill." +
        "\nCapped at {1} kills. Getting hit resets the count";
}