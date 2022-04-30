using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class DwarvenMedallion : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Dwarven Medallion");
        Tooltip.SetDefault("15% increased mining speed" +
                           "\nGenerate Light");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 0, 30);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.pickSpeed -= .15f;
        Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .4f, .5f, .5f);
    }
    public override void AddRecipes()
    {
      CreateRecipe()
     .AddIngredient(ItemID.SilverPickaxe)
     .AddIngredient(ItemID.StoneBlock, 50)
     .AddTile(TileID.Anvils)
     .Register();

      CreateRecipe()
     .AddIngredient(ItemID.TungstenPickaxe)
     .AddIngredient(ItemID.StoneBlock, 50)
     .AddTile(TileID.Anvils)
     .Register();
    }
}