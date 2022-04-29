using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Accessories;

public class FrostGiantHand : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Frost Giant Hand");
        Tooltip.SetDefault($"5% increased {runicText} critical strike chance" +
                           $"\nCritical hit caused by {runicText} weapons release explosive frost sparks" +
                           "\nGrants immunity to fire blocks ");

        // @todo "weapons release explosive frost sparks" needs implementation!

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetCritChance<RunicDamageClass>() += 5;
        player.fireWalk = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.FrostDaggerfish)
        .AddIngredient<FrostCoreBar>(30)
        .AddTile(TileID.WorkBenches)
        .Register();
}