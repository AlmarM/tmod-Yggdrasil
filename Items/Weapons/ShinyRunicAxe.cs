using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class ShinyRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shiny Runic Axe");
        Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Generate a faint light & 3% increased [c/ae804f:runic] critical strike chance" +
            "\n[c/ae804f:Runic Power 2+] Increase attack speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 11;
        Item.crit = 6;
        Item.knockBack = 6;
		Item.axe = 12;
		Item.value = Item.buyPrice(0, 0, 18, 0);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.GoldBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
		
		CreateRecipe()
		.AddIngredient(ItemID.PlatinumBar, 10)
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

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 1)
        {
            crit += 3;
        }

    }
    public override float UseSpeedMultiplier(Player player)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 2)
        {
            return 1.5f;
        }
        return 1f;
    }


}