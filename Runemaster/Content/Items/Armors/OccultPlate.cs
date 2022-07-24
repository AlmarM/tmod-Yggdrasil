using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Body)]
public class OccultPlate : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Occult Plate");
        Tooltip.SetDefault($"Increases {runicText} damage by 2" +
                           $"\n1% increased {runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.value = Item.sellPrice(0, 0, 60);
        Item.rare = ItemRarityID.Orange;
        Item.defense = 6;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 2;
        player.GetCritChance<RunicDamageClass>() += 1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>(15)
        .AddIngredient(ItemID.Bone, 50)
        .AddTile<DvergrForgeTile>()
        .Register();
}