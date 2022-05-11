using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class ProtectiveRuneSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 15+");

        DisplayName.SetDefault("Protective Runic Slab");
        Tooltip.SetDefault($"Displays {runicPowerText}" +
                           $"\nGrants +3 defense" +
                           $"\n{runicPower} Grants an additional +15 defense");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 7);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statDefense += 3;
        player.SetEffect<ProtectiveRuneSlab>();
        player.SetEffect<RunicSlab>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RunicSlab>()
        .AddIngredient(ItemID.TurtleShell)
        .AddTile(TileID.WorkBenches)
        .Register();
}