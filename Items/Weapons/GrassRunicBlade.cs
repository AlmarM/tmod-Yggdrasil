using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;
public class GrassRunicBlade : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Grass Runic Blade");
        Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Has 50% chance to inflict poison based on [c/ae804f:Runic Power]" +
            "\n[c/ae804f:Runic Power 3+] Grants +3 [c/ae804f:runic] damage 2% increased [c/ae804f:runic] critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 0;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(0, 0, 55, 0);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        int poisonTime = (modPlayer.RunePower * 60);
        if (modPlayer.RunePower >= 1)
        {
            if (Main.rand.NextFloat() < .5f)
            {
                target.AddBuff(BuffID.Poisoned, poisonTime);
            }
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 3)
        {
            flat += 3;
        }
    }

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 3)
        {
            crit += 2;
        }

    }

    public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.Stinger, 15)
		.AddIngredient(ItemID.JungleSpores, 15)
		.AddTile(TileID.Anvils)
        .Register();
		

}