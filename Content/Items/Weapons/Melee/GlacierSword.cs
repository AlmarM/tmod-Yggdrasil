using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.FrostCore;

namespace Yggdrasil.Content.Items.Weapons.Melee
{
	public class GlacierSword : YggdrasilItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Glacier Sword");
			Tooltip.SetDefault("That's a cold one");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 18;
			Item.useAnimation = 19;
			Item.knockBack = 5;
			Item.crit = 1;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing; 
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 240);	
		}


		public override void AddRecipes() => CreateRecipe()
		.AddIngredient<FrostCoreSword>()
		.AddIngredient<GlacierShards>(10)
		.AddTile(TileID.MythrilAnvil)
		.Register();

	}
}
