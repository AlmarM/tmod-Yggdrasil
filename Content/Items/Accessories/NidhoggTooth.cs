using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Configs;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.Items.Accessories
{
	public class NidhoggTooth : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
			string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
			string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 10+");

			DisplayName.SetDefault ("Nidhogg's Tooth");
			Tooltip.SetDefault($"{runicPower} 5% increased {runicText} critical strike chance" +
							$"\nHitting an enemy with a {runicText} weapon slows the target by 25% for 3 sec");
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 3);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)	
		{
			player.GetCritChance<RunicDamageClass>() += 5;
			player.GetModPlayer<RunePlayer>().NiddhogToothEquip = true;
			player.GetModPlayer<RunePlayer>().SlowDebuffValue = .75f; //it means 25% slow
		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.SpiderFang, 5)
		.AddIngredient(ItemID.PixieDust, 10)
		.AddIngredient(ItemID.VialofVenom)
		.AddTile(TileID.WorkBenches)
		.Register();

	}
}