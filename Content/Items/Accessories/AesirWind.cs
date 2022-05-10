using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.Items.Accessories;

public class AesirWind : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("Aesir Wind");
        Tooltip.SetDefault($"Allows the holder to double jump" +
                           $"\nIncreases jump height" +
                           "\nNegates fall damage" +
                           $"\n{runicPower} Increases defense by 2");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 3);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<RunePlayer>().AesirWindEquip = true;
        player.jumpSpeedBoost += 2f;
        player.hasJumpOption_Cloud = true;
        player.noFallDmg = true;

    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RuneBag>()
        .AddIngredient(ItemID.LuckyHorseshoe)
        .AddIngredient(ItemID.CloudinaBalloon)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}