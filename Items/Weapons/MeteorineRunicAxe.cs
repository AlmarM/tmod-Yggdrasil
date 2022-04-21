using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class MeteorineRunicAxe : YggdrasilItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Meteorite Runic Axe");
		Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Grants +1 runic damage & has 25% chance to inflict OnFire! for 1 sec"+
							"\n[c/ae804f:Runic Power 2+]: Grants +2 runic damage & adds 25% chance to inflict OnFire! for 2 more sec");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}

	int baseDamage = 17; //base weapon damage used by Item.Damage
	int baseOnFire = 60; //base Onfire time for the debuff
	float baseOnFireChance = 0f;
	
	public override void SetDefaults()
	{
		// Please adjust as needed
		Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 27;
		Item.useAnimation = 27;
		Item.autoReuse = false;
		Item.damage = baseDamage;
		Item.crit = 10;
		Item.knockBack = 7;
		Item.axe = 13;
		Item.value = Item.buyPrice(0, 0, 27, 0);
		Item.rare = ItemRarityID.Blue;
		Item.UseSound = SoundID.Item1;
	}
	
	public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();	
		if (modPlayer.RunePower >= 2)
		{
			Item.damage = baseDamage += 2;
		}
		
		if (modPlayer.RunePower >= 1)
		{
			Item.damage = baseDamage += 1;
		}
		
	}
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();		
		if (modPlayer.RunePower >= 2)
		{
			if (Main.rand.NextFloat() < (baseOnFireChance += .5f))
			{
				target.AddBuff(BuffID.OnFire, baseOnFire *= 3);
			}
		}
		
		if (modPlayer.RunePower >= 1)
		{
			if (Main.rand.NextFloat() < (baseOnFireChance += .25f))
			{
				target.AddBuff(BuffID.OnFire, baseOnFire);
			}
		}	
	}

	public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.MeteoriteBar, 12)
		.AddTile(TileID.Anvils)
		.Register();
		

}
