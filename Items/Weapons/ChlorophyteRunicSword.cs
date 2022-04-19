using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class ChlorophyteRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Chlorophyte Runic Blade");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.autoReuse = false;
        Item.damage = 65;
        Item.crit = 5;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(0, 5, 52, 0);
        Item.rare = ItemRarityID.Lime;
        Item.UseSound = SoundID.Item1;
    }
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Poisoned, 600);
		}

    public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.ChlorophyteBar, 10)
		.AddIngredient(ItemID.MeteoriteBar, 5)
		.AddTile(TileID.Anvils)
        .Register();
		

}