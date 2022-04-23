using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class ShinyRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shiny Runic Sword");
        Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Generate a faint light & Grants +2 [c/ae804f:runic] damage" +
            "\n[c/ae804f:Runic Power 2+] 2% increased [c/ae804f:runic] critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = false;
        Item.damage = 12;
        Item.crit = 0;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(silver: 18);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.GoldBar, 12)
		.AddTile(TileID.Anvils)
        .Register();
		
		CreateRecipe()
		.AddIngredient(ItemID.PlatinumBar, 12)
		.AddTile(TileID.Anvils)
        .Register();
	}

    public override void HoldItem(Player player)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 1)
        {
            Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.4f, 0.4f, 0.1f);
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 1)
        {
            flat += 2;
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

}