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
public class JotunPlate : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Jotun Plate");
        Tooltip.SetDefault($"5% increased {runicText} critical strike chance");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.value = Item.sellPrice(0, 4);
        Item.rare = ItemRarityID.Pink;
        Item.defense = 15;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetCritChance<RunicDamageClass>() += 5;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}