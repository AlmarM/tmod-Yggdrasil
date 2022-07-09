using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Others;

public class StartingNote : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("[c/AE804F:Starting Note Yggdrasil Mod Alpha]");
        Tooltip.SetDefault("Thank you for trying the alpha version of the Yggdrasil mod." +
            "\nThe alpha version contains runes that the player can craft and leave in their inventory to get bonuses." +
            "\nTry for yourself and see what you can do with them!" +
            "\n----" +
            "\nIt also contains progression for a new [c/AE804F:Runemaster] class" +
            "\nTo get you started as a [c/AE804F:Runemaster], craft a Stone Slab as your first [c/AE804F:runic] weapon (go get some stone blocks!)" +
            "\nOnce equipped with a [c/AE804F:runic] weapon a small UI containing two gauges will appear under the character" +
            "\nThe top one is [c/FC7B03:Focus]. It goes up every second and when it's maxed, right click with a [c/AE804F:runic] weapon to release [c/FC7B03:focus] power" +
            "\nEach [c/AE804F:Runemaster] weapon do different things" +
            "\nThe bottom one is [c/CD2340:Insanity]. It goes up every time you attack so keep track of it because if you reach the threshold, you will hurt yourself" +
            "\nThis can kill you, so watch out!" +
            "\nUsing a [c/FC7B03:focus] power will decrease the [c/CD2340:insanity] value by a certain amount. Use that to your advantage" +
            "\n[c/CD2340:Insanity] also decreases by itself over time" +
            "\nThe content progression for the [c/AE804F:Runemaster] class in term of items is still being developped but goes all the way to moonlord" +
            "\n----" +
            "\nThe alpha version also containes a bunch of accessories, new enemies, a town NPC, an event, new resources and small things." +
            "\nYou should head to the snow biome when you feel like it!" +
            "\nWe hope you enjoy!" +
            "\n[c/AE804F:Skal!]");

    }

    public override void SetDefaults()
    {
        Item.maxStack = 1;
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()

        .Register();

}