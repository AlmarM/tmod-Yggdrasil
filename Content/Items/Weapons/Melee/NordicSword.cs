using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Ores;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Content.Items.Weapons.Melee
{
	public class NordicSword : YggdrasilItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Nordic Sword");
			Tooltip.SetDefault("So cold, they stay in place");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 110;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.knockBack = 7;
			Item.crit = 1;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing; 
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 600);
			target.AddBuff(ModContent.BuffType<SlowDebuff>(), 90);
		}


		public override void AddRecipes() => CreateRecipe()
			.AddIngredient<GlacierSword>()
			.AddIngredient<ColdIronBar>(5)
			.AddIngredient<NordicWood>(10)
			.AddTile(TileID.MythrilAnvil)
			.Register();

	}
}
