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
		Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Grants +1 [c/ae804f:runic] damage & has 25% chance to inflict fire damage for 1 sec"+
							"\n[c/ae804f:Runic Power 2+]: Grants +2 [c/ae804f:runic] damage & adds 25% chance to inflict fire damage for 2 more sec");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}
	
	public override void SetDefaults()
	{
		// Please adjust as needed
		Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 27;
		Item.useAnimation = 27;
		Item.autoReuse = false;
		Item.damage = 17;
		Item.crit = 7;
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
			flat += 2;
		}
		
		if (modPlayer.RunePower >= 1)
		{
			flat += 1;
		}
	}
	
	int baseOnFire = 60; //base Onfire time for the debuff 60 = 1sec
	float baseOnFireChance = 0f;
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();		
		float onFireProcChance = baseOnFireChance;
		
		if (modPlayer.RunePower >= 1)
		{
			onFireProcChance += .25f;
			if (Main.rand.NextFloat() < onFireProcChance)
			{
				// use base time if 1 rune power will never increase the duration
				target.AddBuff(BuffID.OnFire, baseOnFire);
			}
		}
		
		
		int onFireDuration = baseOnFire;
		
		if (modPlayer.RunePower >= 2)
		{
			onFireProcChance += .5f;
			onFireDuration *= 3;
			
			if (Main.rand.NextFloat() < onFireProcChance)
			{
				target.AddBuff(BuffID.OnFire, onFireDuration);
			}
		}
		
	}

	public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.MeteoriteBar, 12)
		.AddTile(TileID.Anvils)
		.Register();
}