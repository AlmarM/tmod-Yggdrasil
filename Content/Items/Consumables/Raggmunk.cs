using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Consumables;

public class Raggmunk : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Raggmunk");

        Tooltip.SetDefault("Minor improvements to all stats\nA Sweddish classic! Don't forget the lingon");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

	public override void SetDefaults()
	{
		Item.rare = ItemRarityID.Blue;
		Item.maxStack = 99;
		Item.noUseGraphic = true;
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useTime = Item.useAnimation = 30;
		Item.value = Item.buyPrice(0, 0, 0, 10);

		Item.buffType = BuffID.WellFed;
		Item.buffTime = 36000;
		Item.noMelee = true;
		Item.consumable = true;
		Item.UseSound = SoundID.Item2;
		Item.autoReuse = false;

	}

}