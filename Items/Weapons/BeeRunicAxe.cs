using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class BeeRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Queen Bee Runic Axe");
        Tooltip.SetDefault("[c/ae804f:Runic Power 2+]: Apply Honey on hit for [c/ae804f:Runic Power] seconds" +
            "\nGrants +3 [c/ae804f:runic] damage");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 27;
        Item.crit = 6;
        Item.knockBack = 7;
		Item.axe = 14;
		Item.value = Item.buyPrice(0, 1, 0, 0);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 2)
        {
            player.AddBuff(BuffID.Honey, (modPlayer.RunePower * 60));
        }
      
	}

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 2)
        {
            flat += 3;
        }
    }


}