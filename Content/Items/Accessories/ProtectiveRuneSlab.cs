using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class ProtectiveRuneSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        DisplayName.SetDefault("Protective Runic Slab");
        Tooltip.SetDefault($"Increases defense by 8" +
            "\nReduces damage taken by 5%" +
            $"\nIncreases {insanityText} removed by {focusText} power by 2");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 7);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statDefense += 8;
        player.GetModPlayer<RunePlayer>().InsanityRemoverValue += 2;
        player.endurance += 0.05f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RunicSlab>()
        .AddIngredient(ItemID.TurtleShell)
        .AddTile<DvergrForgeTile>()
        .Register();
}