using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunicSlab : YggdrasilItem
{
    //Display of focus and insanity is temporary as it will be turned into UI element under the player
    public override void SetStaticDefaults()
    {
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        DisplayName.SetDefault("Runic Slab");
        Tooltip.SetDefault($"Increases {insanityText} gauge by 2");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 2);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<RunemasterPlayer>().InsanityThreshold += 2;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10)
        //.AddIngredient(ItemID.Lens)
        .AddTile(TileID.WorkBenches)
        .Register();
}