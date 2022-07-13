using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.Melee;

namespace Yggdrasil.Content.Items.Weapons.Melee
{
	public class NordicSpear : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nordic Spear");
			Tooltip.SetDefault("So cold, they stay in place");

			ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 100;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8;
			Item.crit = 2;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.shootSpeed = 3.5f;
			Item.shoot = ModContent.ProjectileType<NordicSpearProjectile>();

			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient<ColdIronBar>(6)
		.AddIngredient<NordicWood>(10)
		.AddTile(TileID.MythrilAnvil)
		.Register();

	}
}
