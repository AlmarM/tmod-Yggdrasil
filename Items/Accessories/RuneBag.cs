using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class RuneBag : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("RuneBag");
			Tooltip.SetDefault("2% increased [c/ae804f:runic] damage for every 3 [c/ae804f:Runic Power]"+
				"\nDisplay[c/ae804f: Runic Power]");
				
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)	
		{
			var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
			player.GetDamage<RunicDamageClass>() += (0.02f * (modPlayer.RunePower / 3)) ;	
			modPlayer.showRunePower = true;
			
		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "Linnen", 5)
		.AddIngredient(Mod, "RunicSlab")
		.AddTile(TileID.WorkBenches)
        .Register();
		
	}
}
