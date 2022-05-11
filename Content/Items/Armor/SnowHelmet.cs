using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class SnowHelmet : YggdrasilItem
{

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Snow Helmet");
        Tooltip.SetDefault($"It's cold");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.defense = 2;
        Item.value = Item.sellPrice(0, 0, 5);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<SnowPlate>() &&
               legs.type == ModContent.ItemType<SnowBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Grants + 1 defense" +
                          "\nGrants an additional 4 defense in snow biome";

        player.statDefense += 1;

        if (player.ZoneSnow)
        {
            player.statDefense += 4;
        }
    }

    public override void UpdateEquip(Player player)
    {
        
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SnowBlock, 30)
        .Register();
}