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
public class GlacierPlate : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Glacier Plate");
        Tooltip.SetDefault($"4% increased {runicText} critical strike chance");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.LightRed;
        Item.defense = 13;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetCritChance<RunicDamageClass>() += 4;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(5)
        .AddIngredient<GlacierShards>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}