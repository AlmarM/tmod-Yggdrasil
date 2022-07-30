using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Ores;
using Yggdrasil.Extensions;
using Yggdrasil.Frostcore.Content.Items.Armors;

namespace Yggdrasil.Nordic.Content.Items.Armors;

[AutoloadEquip(EquipType.Head)]
public class NordicHaume : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nordic Haume");
        Tooltip.SetDefault("Increases critical strike chance by 5%");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.defense = 20;
        Item.value = Item.sellPrice(0, 5);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<NordicPlate>() &&
               legs.type == ModContent.ItemType<NordicGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Attackers get slowed\nAttackers also take double damage\nGrants 5% damage reduction";

        player.SetEffect<NordicHaume>();
        player.thorns += 2f;
        player.endurance += 0.05f;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetCritChance(DamageClass.Generic) += 5;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreHelmet>()
        .AddIngredient<ColdIronBar>(5)
        .AddTile(TileID.MythrilAnvil)
        .Register();
}