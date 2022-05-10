using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Accessories;

public class ProtectiveRuneSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 15+");

        DisplayName.SetDefault("Protective Runic Slab");
        Tooltip.SetDefault($"Displays {runicPowerText}"+
                           $"\nIncreases defense by 3" +
                           $"\n{runicPower} Increases defense by an additional 15");

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
        var modPlayer = player.GetModPlayer<RunePlayer>();
        modPlayer.ShowRunePower = true;
        player.statDefense += 3;
        player.GetModPlayer<RunePlayer>().ProtectiveSlabEquip = true;

        
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RunicSlab>()
        .AddIngredient(ItemID.TurtleShell)
        .AddTile<DvergrForgeTile>()
        .Register();
}