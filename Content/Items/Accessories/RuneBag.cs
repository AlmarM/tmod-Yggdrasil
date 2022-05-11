using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RuneBag : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");

        DisplayName.SetDefault("RuneBag");
        Tooltip.SetDefault($"2% increased {runicText} damage for every 3 {runicPowerText}" +
                           $"\nGrants +1 {runicPowerText}" +
                           $"\nDisplays {runicPowerText}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 0, 25);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        var modPlayer = player.GetModPlayer<RunePlayer>();
        player.GetModPlayer<RunePlayer>().RunePower += 1;
        player.GetDamage<RunicDamageClass>() += 0.02f * (modPlayer.RunePower / 3f);
        player.SetEffect<RunicSlab>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddIngredient<RunicSlab>()
        .AddTile(TileID.WorkBenches)
        .Register();
}