using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Weapons.FrostCore
{
	public class FrostcoreSpear : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostcore Spear");
			Tooltip.SetDefault("50% chance to frostburn target for 3 sec");

			ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 18;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4;
			Item.crit = 0;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.shootSpeed = 3.5f;
			Item.shoot = ModContent.ProjectileType<FrostcoreSpearProjectile>();

			Item.value = Item.sellPrice(0, 0, 23, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;

		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient<FrostcoreBar>(8)
		.AddTile(TileID.Anvils)
		.Register();

	}
}
