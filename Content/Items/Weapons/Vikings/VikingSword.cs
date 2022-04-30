using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Weapons.Vikings
{
	public class VikingSword : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viking Sword");
			//Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 34;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.axe = 12;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.crit = 0;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

	}
}
