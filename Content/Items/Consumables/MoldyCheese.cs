using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Consumables;

public class MoldyCheese : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moldy Cheese");

        Tooltip.SetDefault("Minor improvements to all stats" +
                           "\nEat at your own risk, I mean, it's like blue cheese isn't it?");

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
        Item.buffTime = TimeUtils.MinutesToTicks(12);
        Item.noMelee = true;
        Item.consumable = true;
        Item.UseSound = SoundID.Item2;
        Item.autoReuse = false;
    }

    public override void OnConsumeItem(Player player)
    {
        player.AddBuff(BuffID.Poisoned, TimeUtils.SecondsToTicks(10));
    }
}