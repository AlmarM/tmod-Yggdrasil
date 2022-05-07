using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.Items.Accessories;

public class FrostGiantHand : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 5+");

        DisplayName.SetDefault("Frost Giant Hand");
        Tooltip.SetDefault($"5% increased {runicText} critical strike chance" +
                           $"\nGrants immunity to fire blocks" +
                           $"\n{runicPower} Critical hit caused by {runicText} weapons releases many frost sparks");

        // @todo "weapons release explosive frost sparks" needs implementation!

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 2);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetCritChance<RunicDamageClass>() += 5;
        player.fireWalk = true;
        player.GetModPlayer<RunePlayer>().FrostGiantHandEquip = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.FrostDaggerfish)
        .AddIngredient<FrostcoreBar>(30)
        .AddTile(TileID.WorkBenches)
        .Register();
}