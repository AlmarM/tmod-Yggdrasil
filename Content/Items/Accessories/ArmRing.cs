using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.Items.Accessories;

public class ArmRing : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("Armring");
        Tooltip.SetDefault($"2% increase {runicText} damage"+
                           $"\nGrants +1 {runicPowerText}"+
                           $"\n{runicPower} 1% increase {runicText} damage");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 0, 10);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.02f;
        player.GetModPlayer<RunePlayer>().RunePower += 1;
        player.GetModPlayer<RunePlayer>().ArmRingEquip = true;

    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<WoodArmRing>()
        .AddRecipeGroup(RecipeGroupID.IronBar, 2)
        .AddTile(TileID.Anvils)
        .Register();
}