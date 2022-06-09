using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class VikingLeatherHelmet : YggdrasilItem
{

    public override void SetStaticDefaults()
    {

        DisplayName.SetDefault("Viking Helmet");
        //Tooltip.SetDefault("");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.defense = 3;
        Item.value = Item.sellPrice(0, 0, 5);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<VikingLeatherShirt>() &&
               legs.type == ModContent.ItemType<VikingLeatherBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        player.setBonus = $"Increases {runicText} damage by 1" +
                          $"\n1% increased {runicText} critical strike chance" +
                          "\nIncreases defense by 1";

        player.GetDamage<RunicDamageClass>().Flat += 1;
        player.GetCritChance<RunicDamageClass>() += 1;
        player.statDefense += 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddIngredient(ItemID.CopperBar)
        .AddTile(TileID.Anvils)
        .Register();

        CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddIngredient(ItemID.TinBar)
        .AddTile(TileID.Anvils)
        .Register();

    }
}