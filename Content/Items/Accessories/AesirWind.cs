using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Weapons.RuneTablets;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class AesirWind : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        
        DisplayName.SetDefault("Aesir Wind");
        Tooltip.SetDefault($"Allows the holder to double jump" +
                           $"\nIncreases jump height" +
                           "\nNegates fall damage" +
                           $"\nIncreases defense by 2");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.jumpSpeedBoost += 2f;
        player.hasJumpOption_Cloud = true;
        player.noFallDmg = true;
        player.statDefense += 2;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RuneBag>()
        .AddIngredient(ItemID.LuckyHorseshoe)
        .AddIngredient(ItemID.CloudinaBalloon)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}