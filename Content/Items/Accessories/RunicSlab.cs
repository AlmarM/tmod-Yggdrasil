using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunicSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");

        DisplayName.SetDefault("Runic Slab");
        Tooltip.SetDefault($"Displays {runicPowerText}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = false;
    }

    public override void UpdateInventory(Player player)
    {
        var modPlayer = player.GetModPlayer<RunePlayer>();
        modPlayer.ShowRunePower = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10)
        .AddIngredient(ItemID.Lens)
        .AddTile(TileID.WorkBenches)
        .Register();
}