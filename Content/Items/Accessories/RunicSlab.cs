using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunicSlab : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Slab");
        Tooltip.SetDefault($"Displays focus and instaniy");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.accessory = false;
        Item.value = Item.buyPrice(0, 0, 2);
    }

    public override void UpdateInventory(Player player)
    {
        player.SetEffect<RunicSlab>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10)
        .AddIngredient(ItemID.Lens)
        .AddTile(TileID.WorkBenches)
        .Register();
}