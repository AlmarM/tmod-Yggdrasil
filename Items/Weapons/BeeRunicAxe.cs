using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class BeeRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Queen Bee Runic Axe");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
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
        Item.damage = 27;
        Item.crit = 10;
        Item.knockBack = 7;
		Item.axe = 14;
		Item.value = Item.buyPrice(0, 1, 0, 0);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
		player.AddBuff(BuffID.Honey, 120);
	}
		

}