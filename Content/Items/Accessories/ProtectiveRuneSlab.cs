using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class ProtectiveRuneSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 15+");

        DisplayName.SetDefault("Protective Runic Slab");
        Tooltip.SetDefault($"Displays {runicPowerText}"+
                           $"\nGrants +3 defense"+
                           $"\n{runicPower} Grants an additional +15 defense");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;
        Item.accessory = false;
        Item.value = Item.buyPrice(0, 7);
    }

    public override void UpdateInventory(Player player)
    {
        var modPlayer = player.GetModPlayer<RunePlayer>();
        modPlayer.ShowRunePower = true;
        player.statDefense += 3;

        if (modPlayer.RunePower >= 15)
        {
            player.statDefense += 15;
        }
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RunicSlab>()
        .AddIngredient(ItemID.TurtleShell)
        .AddTile(TileID.WorkBenches)
        .Register();
}