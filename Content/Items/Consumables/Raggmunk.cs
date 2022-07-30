using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Consumables;

public class Raggmunk : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Raggmunk");

        Tooltip.SetDefault("Minor improvements to all stats" +
                           "\nA Sweddish classic! Don't forget the lingon");

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
        Item.buffType = BuffID.WellFed;
        Item.buffTime = TimeUtils.MinutesToTicks(10);
        Item.noMelee = true;
        Item.consumable = true;
        Item.UseSound = SoundID.Item2;
        Item.autoReuse = false;
    }
}