using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class BerserkerRing : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Berserker Ring");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\n3% increased {runicText} critical strike chance" +
                           $"\nGrants +1 {runicPowerText}" +
                           "\nIncreases defense by 2" +
                           $"\n{runicPower} 1% increased {runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Green;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.1f;
        player.GetCritChance<RunicDamageClass>() += 3;
        player.GetModPlayer<RunePlayer>().RunePower += 1;
        player.SetEffect<BerserkerRing>();
        player.statDefense += 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<ArmRing>()
            .AddIngredient(ItemID.VilePowder, 5)
            .AddTile<DvergrForgeTile>()
            .Register();

        CreateRecipe()
            .AddIngredient<ArmRing>()
            .AddIngredient(ItemID.ViciousPowder, 5)
            .AddTile<DvergrForgeTile>()
            .Register();
    }
}