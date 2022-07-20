using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

[AutoloadEquip(EquipType.Neck)]
public class DwarvenMedallion : YggdrasilItem
{
    
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dwarven Medallion");
        Tooltip.SetDefault("15% increased mining speed" +
                           "\nGenerates Light" +
                           "\nIncreases defense by 1");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 30);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.pickSpeed -= .15f;
        if (player.ZoneRockLayerHeight)
        {
            player.statDefense += 1;
        }

        Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .4f, .5f, .5f);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.SilverPickaxe)
            .AddIngredient(ItemID.StoneBlock, 50)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.TungstenPickaxe)
            .AddIngredient(ItemID.StoneBlock, 50)
            .AddTile(TileID.Anvils)
            .Register();
    }
}