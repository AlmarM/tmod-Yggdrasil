using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class ArmRing : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Armring");
        Tooltip.SetDefault($"Increase {runicText} damage by 2");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        //player.GetDamage<RunicDamageClass>() += 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.IronBar, 2)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.LeadBar, 2)
            .AddTile(TileID.Anvils)
            .Register();
    }
}