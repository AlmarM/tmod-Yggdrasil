using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Projectiles;
using Terraria.GameContent.Creative;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;
public class OccultRunicAxe : YggdrasilItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Occult Runic Axe");
		Tooltip.SetDefault("[c/ae804f:Runic Power 2+]: Increase attack speed" +
							"\n[c/ae804f:Runic Power 3+]: Can be thrown");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}

	public override void SetDefaults()
	{
		Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
		Item.damage = 25;
		Item.useTime = 28;
		Item.useAnimation = 28;
		Item.axe = 14;
		Item.knockBack = 5;
		Item.crit = 6;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Green;
		//Item.shoot = ModContent.ProjectileType<OccultAxeProjectile>();
		//Item.shootSpeed = 12f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = false;
	}
		
	public override bool AltFunctionUse(Player player) {
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 3)
		{
			return true;
		}
		return false;
	}

	public override bool CanUseItem(Player player) {
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 3)
		{

			if (player.altFunctionUse == 2)
			{
				Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
				Item.useTime = 28;
				Item.useAnimation = 28;
				Item.noMelee = true;
				Item.noUseGraphic = true;
				Item.shoot = ModContent.ProjectileType<OccultAxeProjectile>();
				Item.shootSpeed = 15f;
			}
			else
			{
				Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
				Item.noUseGraphic = false;
				Item.useTime = 28;
				Item.useAnimation = 28;
				Item.noMelee = false;
				Item.shoot = ProjectileID.None;
			}
			
		}
		return true;
	}

	public override float UseSpeedMultiplier(Player player)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 2)
		{
			return 1.25f;
		}
		return 1f;
	}

	public override void AddRecipes() => CreateRecipe()
		.AddIngredient(Mod, "OccultShard", 10)
		.AddTile(TileID.Anvils)
		.Register();
}