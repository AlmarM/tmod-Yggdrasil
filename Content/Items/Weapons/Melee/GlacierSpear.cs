using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.FrostCore;
using Yggdrasil.Content.Projectiles.Melee;

namespace Yggdrasil.Content.Items.Weapons.Melee
{
	public class GlacierSpear : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Spear");
			Tooltip.SetDefault("That's a cold one");

			ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4;
			Item.crit = 0;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.shootSpeed = 6f;
			Item.shoot = ModContent.ProjectileType<GlacierSpearProjectile>();

			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient<FrostCoreSpear>()
		.AddIngredient<GlacierShards>(10)
		.AddTile(TileID.MythrilAnvil)
		.Register();

	}
}
