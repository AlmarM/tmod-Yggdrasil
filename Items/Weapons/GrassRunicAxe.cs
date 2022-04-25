using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class GrassRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Grass Runic Axe");
        Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Has 50% chance to inflict poison based on [c/ae804f:Runic Power]" +
            "\n[c/ae804f:Runic Power 2+] 5% increased [c/ae804f:runic] critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 22;
        Item.crit = 6;
        Item.knockBack = 6;
		Item.axe = 14;
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

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 2)
        {
            crit += 5;
        }

    }

    public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.Stinger, 15)
		.AddIngredient(ItemID.JungleSpores, 15)
		.AddTile(TileID.Anvils)
        .Register();
		

}