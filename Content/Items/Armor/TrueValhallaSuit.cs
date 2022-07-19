using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class TrueValhallaSuit : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("True Valhalla Suit");
        Tooltip.SetDefault($"10% increased {runicText} critical strike chance");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.value = Item.sellPrice(0, 6);
        Item.rare = ItemRarityID.Yellow;
        Item.defense = 25;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetCritChance<RunicDamageClass>() += 10;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SquireAltShirt) //Valhalla Breastplate
        .AddIngredient<TrueHeroFragment>()
        .AddIngredient<SunPebble>()
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}