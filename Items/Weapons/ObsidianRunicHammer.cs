using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class ObsidianRunicHammer : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Obsidian Runic Hammer");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 32;
        Item.crit = 4;
        Item.knockBack = 10;
		Item.hammer = 70;
		Item.value = Item.buyPrice(0, 0, 55, 0);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }
	
	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
	{
		if (Main.rand.NextFloat() < .5f)
		{
			target.AddBuff(BuffID.OnFire, 120);
		}
	}

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HellstoneBar, 20)
		.AddIngredient(ItemID.Obsidian, 20)
		.AddTile(TileID.Anvils)
        .Register();
		
}