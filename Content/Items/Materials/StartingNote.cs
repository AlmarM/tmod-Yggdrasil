using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class StartingNote : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Starting Note Yggdrasil Mod Alpha");
        Tooltip.SetDefault("Thank you for trying the alpha version of the Yggdrasil mod." +
            "\nThe alpha version contains runes that the player can craft and leave in their inventory to get bonuses." +
            "\nTry for yourself and see what you can do with them!" +
            "\n----" +
            "\nIt also contains progression for a Runemaster class" +
            "\nTo get you started as a Runemaster, craft a Stone Slab as your first weapon (go get some stone blocks!)." +
            "\nAs UI for the class is not integrated yet, craft yourself a runic slab too (with stone blocks) and equip it!" +
            "\nWith it, you will now see your focus value and your insanity value under the minimap." +
            "\nFocus goes up every second and when it's maxed, right click with a runic weapon to release focus power" +
            "\nEach Runemaster tablets do different things" +
            "\nInsanity goes up everytime you attack so keep track of the number because if you reach the threshold, you will hurt yourself" +
            "\nThis can also kill you so watch out!" +
            "\nUsing a focus power will decrease the insanity value by a certain amount. Use that to your advantage" +
            "\nInstanity also decreases by itself over time" +
            "\nThe progression for the Runemaster class in term of items goes all the way to hardmode. The rest is being developped right now." +
            "\n----" +
            "\nThe alpha version also containes a bunch of accessories, new enemies, new resources and small things." +
            "\nYou should head to the snow biome when you feel like it!" +
            "\nWe hope you enjoy!" +
            "\nSkal!");

    }

    public override void SetDefaults()
    {
        Item.maxStack = 1;
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()

        .Register();

}