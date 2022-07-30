using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Consumables;

public class MoldyCheeseSoup : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moldy Cheese Soup");

        Tooltip.SetDefault("Medium improvements to all stats" +
                           "\nAre you seriously going to eat that?");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.maxStack = 99;
        Item.noUseGraphic = true;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.value = Item.sellPrice(copper: 10);
        Item.buffType = BuffID.WellFed2;
        Item.buffTime = TimeUtils.MinutesToTicks(10);
        Item.noMelee = true;
        Item.consumable = true;
        Item.UseSound = SoundID.Item2;
        Item.autoReuse = false;
    }

    public override void OnConsumeItem(Player player)
    {
        player.AddBuff(BuffID.Poisoned, TimeUtils.SecondsToTicks(10));
        player.AddBuff(BuffID.Stinky, TimeUtils.MinutesToTicks(5));
        player.AddBuff(BuffID.WeaponImbueIchor, TimeUtils.MinutesToTicks(10));
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MoldyCheese>()
        .AddIngredient(ItemID.Bowl)
        .AddIngredient(ItemID.BottledWater)
        .AddTile(TileID.CookingPots)
        .Register();
}