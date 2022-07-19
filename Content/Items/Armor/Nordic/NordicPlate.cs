using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Armor.Nordic;

[AutoloadEquip(EquipType.Body)]
public class NordicPlate : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nordic Plate");
        Tooltip.SetDefault("Increases damage by 10%");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.defense = 26;
        Item.value = Item.sellPrice(0, 5);
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Generic) += 0.1f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCorePlate>()
        .AddIngredient<ColdIronBar>(5)
        .AddTile(TileID.Anvils)
        .Register();
}