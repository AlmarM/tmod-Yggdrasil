using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]

public class FrostGiantHand : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Frost Giant Hand");
        Tooltip.SetDefault($"5% increased {runicText} critical strike chance" +
                           $"\nGrants immunity to fire blocks" +
                           $"\nCritical hit caused by {runicText} weapons releases many frost sparks");

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
        player.SetEffect<FrostGiantHand>();
        player.fireWalk = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.FrostDaggerfish)
        .AddIngredient<FrostCoreBar>(10)
        .AddTile<DvergrForgeTile>()
        .Register();
}