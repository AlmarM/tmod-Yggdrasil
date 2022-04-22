using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class RunemasterCrest : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Runemaster Crest");
			Tooltip.SetDefault("12% increased [c/ae804f:runic] damage"+
			"\n10% increased [c/ae804f:runic] critical strike chance");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.Pink;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 6, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage<RunicDamageClass>() += 0.12f;
			player.GetCritChance<RunicDamageClass>() += 10;
		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "RunemasterEmblem")
		.AddIngredient(ItemID.SoulofFright, 5)
		.AddIngredient(ItemID.SoulofMight, 5)
		.AddIngredient(ItemID.SoulofSight, 5)
		.AddTile(114) //Tinkerer's Workshop
        .Register();
	}
}