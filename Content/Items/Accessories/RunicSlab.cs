using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunicSlab : YggdrasilItem
{
    //Display of focus and insanity is temporary as it will be turned into UI element under the player
    public override void SetStaticDefaults()
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        var insanityColored = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        string focusLine = $"{focusColored}";
        string insanityLine = $"{insanityColored}";

        DisplayName.SetDefault("Runic Slab");
        Tooltip.SetDefault($"Displays {focusLine} and {insanityColored}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = false;
        Item.value = Item.buyPrice(0, 0, 2);
    }

    public override void UpdateInventory(Player player)
    {
        player.SetEffect<RunicSlab>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10)
        .AddTile(TileID.WorkBenches)
        .Register();
}