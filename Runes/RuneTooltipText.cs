namespace Yggdrasil.Runes;

public class RuneTooltipText
{
    public string Name { get; set; }

    public string DescriptionFormat { get; set; }

    public string EffectDescriptionFormat { get; set; }

    public static RuneTooltipText Algiz = new()
    {
        Name = "Algiz",
        DescriptionFormat = "A {0} rune granting defense.",
        EffectDescriptionFormat = "Increases defense by {0}"
    };

    public static RuneTooltipText Ansuz = new()
    {
        Name = "Ansuz",
        DescriptionFormat = "A {0} rune granting wisdom.",
        EffectDescriptionFormat = "Grants +{0} mana"
    };

    public static RuneTooltipText Berkano = new()
    {
        Name = "Berkano",
        DescriptionFormat = "A {0} rune granting regeneration.",
        EffectDescriptionFormat = "Grants +{0} life regen and +{1} mana regen"
    };

    public static RuneTooltipText Dagaz = new()
    {
        Name = "Dagaz",
        DescriptionFormat = "A {0} rune granting awareness.",
        EffectDescriptionFormat = "Grants +{0}% range damage"
    };

    public static RuneTooltipText Ehwaz = new()
    {
        Name = "Ehwaz",
        DescriptionFormat = "A {0} rune granting transportation.",
        EffectDescriptionFormat = "Grants +{0}% movement and max speed"
    };

    public static RuneTooltipText Eihwaz = new()
    {
        Name = "Eihwaz",
        DescriptionFormat = "A {0} rune granting strength.",
        EffectDescriptionFormat = "Grants +{0}% melee damage"
    };

    public static RuneTooltipText Fehu = new()
    {
        Name = "Fehu",
        DescriptionFormat = "A {0} rune granting fate.",
        EffectDescriptionFormat = "Grants +{0}% critical chance"
    };

    public static RuneTooltipText Gebo = new()
    {
        Name = "Gebo",
        DescriptionFormat = "A {0} rune granting unity.",
        EffectDescriptionFormat = "Grants +{0}% minion damage"
    };

    public static RuneTooltipText Hagalaz = new()
    {
        Name = "Hagalaz",
        DescriptionFormat = "A {0} rune granting wrath.",
        EffectDescriptionFormat = "Grants +{0}% magic damage"
    };

    public static RuneTooltipText Ingwaz = new()
    {
        Name = "Ingwaz",
        DescriptionFormat = "A {0} rune granting internal growth.",
        EffectDescriptionFormat = "Grants +{0} max life"
    };

    public static RuneTooltipText Isa = new()
    {
        Name = "Isa",
        DescriptionFormat = "A {0} rune giving a challenge.",
        EffectDescriptionFormat = "+{0}% dmg when at below {1}% HP"
    };

    public static RuneTooltipText Jera = new()
    {
        Name = "Jera",
        DescriptionFormat = "A {0} rune granting peace.",
        EffectDescriptionFormat = "Removes {0} Aggro"
    };

    public static RuneTooltipText Kenaz = new()
    {
        Name = "Kenaz",
        DescriptionFormat = "A {0} rune granting vision.",
        EffectDescriptionFormat = "Grants +{0}% dodge chance"
    };

    public static RuneTooltipText Laguz = new()
    {
        Name = "Laguz",
        DescriptionFormat = "A {0} rune granting renewal.",
        EffectDescriptionFormat = "Heals {0} every {1} seconds"
    };

    public static RuneTooltipText Mannaz = new()
    {
        Name = "Mannaz",
        DescriptionFormat = "A {0} rune granting individuality.",
        EffectDescriptionFormat = "Grants +{0}% damage when there is only one enemy in your vicinity"
    };

    public static RuneTooltipText Nauthiz = new()
    {
        Name = "Nauthiz",
        DescriptionFormat = "A {0} rune granting freedom.",
        EffectDescriptionFormat = "Grants {0} seconds of invincibility"
    };

    public static RuneTooltipText Othala = new()
    {
        Name = "Othala",
        DescriptionFormat = "A {0} rune granting pocession.",
        EffectDescriptionFormat = "Grants {0}% chance to not consume ammo"
    };

    public static RuneTooltipText Perthro = new()
    {
        Name = "Perthro",
        DescriptionFormat = "A {0} rune granting mystery.",
        EffectDescriptionFormat = "Hitting an enemy has a {0}% chance to inflict a random debuff for {1} seconds"
    };

    public static RuneTooltipText Raidho = new()
    {
        Name = "Raidho",
        DescriptionFormat = "A {0} rune granting fury.",
        EffectDescriptionFormat = "Grants +{0}% throw damage"
    };

    public static RuneTooltipText Sowilo = new()
    {
        Name = "Sowilo",
        DescriptionFormat = "A {0} rune granting success.",
        EffectDescriptionFormat = "Grants +{0} armor penetration"
    };

    public static RuneTooltipText Thurisaz = new()
    {
        Name = "Thurisaz",
        DescriptionFormat = "A {0} rune granting spikes.",
        EffectDescriptionFormat = "Grants +{0}% thorns"
    };

    public static RuneTooltipText Tiwaz = new()
    {
        Name = "Tiwaz",
        DescriptionFormat = "A {0} rune granting honor.",
        EffectDescriptionFormat = "Grants +{0}% runic damage"
    };

    public static RuneTooltipText Uruz = new()
    {
        Name = "Uruz",
        DescriptionFormat = "A {0} rune granting speed.",
        EffectDescriptionFormat = "Grants +{0}% melee speed"
    };

    public static RuneTooltipText Wunjo = new()
    {
        Name = "Wunjo",
        DescriptionFormat = "A {0} rune granting comfort.",
        EffectDescriptionFormat = "Grants {0}% damage reduction"
    };
}