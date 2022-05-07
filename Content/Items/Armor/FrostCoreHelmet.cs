using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;


namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class FrostCoreHelmet : YggdrasilItem
{

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("FrostCore Helmet");
        Tooltip.SetDefault("It's really cold!"+
                            "\nAttackers also take some damage");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.defense = 5;
        Item.value = Item.sellPrice(0, 0, 60);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<FrostCorePlate>() &&
               legs.type == ModContent.ItemType<FrostCoreBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Provides extra mobility on ice" + 
                          "\nIce will not break when you fall on it" +
                          "\nGrants immunity to Chilled and Frozen";

        player.iceSkate = true;
        player.buffImmune[BuffID.Chilled] = true;
        player.buffImmune[BuffID.Frozen] = true;

    }

    public override void UpdateEquip(Player player)
    {
        player.thorns += .05f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(10)
        .AddTile(TileID.Anvils)
        .Register();
}