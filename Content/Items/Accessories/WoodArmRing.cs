using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class WoodArmRing : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");

        DisplayName.SetDefault("Wooden Armring");
        Tooltip.SetDefault($"Grants +1 {runicPowerText}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 0, 0, 50);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<RunePlayer>().RunePower += 1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 10)
        .AddTile(TileID.WorkBenches)
        .Register();
}