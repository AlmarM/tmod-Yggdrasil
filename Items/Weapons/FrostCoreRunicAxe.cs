using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class FrostCoreRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("FrostCore Runic Axe");
        Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Grants +1 [c/ae804f:runic] damage & has 50% chance to inflict frostburn for 1 sec" +
                            "\n[c/ae804f:Runic Power 2+]: Grants +1 [c/ae804f:runic] damage & 2% increased [c/ae804f:runic] critical strike chance" +
                            "\nAdds 25% chance to inflict frostburn for 2 more sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.autoReuse = false;
        Item.damage = 20;
        Item.crit = 6;
        Item.knockBack = 6;
		Item.axe = 13;
		Item.value = Item.buyPrice(0, 0, 23, 0);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "FrostCoreBar", 12)
        .AddTile(TileID.Anvils)
        .Register();


	public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 2)
		{
			flat += 1;
		}

		if (modPlayer.RunePower >= 1)
		{
			flat += 1;
		}
	}

	public override void ModifyWeaponCrit(Player player, ref int crit)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 2)
		{
			crit += 2;
		}

	}

	int baseFrostburn = 60; //base Onfire time for the debuff 60 = 1sec
	float baseFrostBurnChance = 0f;

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		float frostBurnProcChance = baseFrostBurnChance;

		if (modPlayer.RunePower >= 1)
		{
			frostBurnProcChance += .5f;
			if (Main.rand.NextFloat() < frostBurnProcChance)
			{
				// use base time if 1 rune power will never increase the duration
				target.AddBuff(BuffID.Frostburn, baseFrostburn);
			}
		}


		int onFireDuration = baseFrostburn;

		if (modPlayer.RunePower >= 2)
		{
			frostBurnProcChance += .25f;
			onFireDuration *= 3;

			if (Main.rand.NextFloat() < frostBurnProcChance)
			{
				target.AddBuff(BuffID.Frostburn, onFireDuration);
			}
		}
		//Main.NewText(frostBurnProcChance);

	}


}