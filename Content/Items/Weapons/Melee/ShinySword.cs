using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Weapons.Melee;

public class ShinySword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shiny Sword");
        Tooltip.SetDefault("It glows");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 12;
        Item.DamageType = DamageClass.Melee;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.knockBack = 3;
        Item.crit = 0;
        Item.value = Item.sellPrice(silver: 18);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
        Item.useStyle = ItemUseStyleID.Swing;
    }

    public override void HoldItem(Player player)
    {
        var centerX = (int)player.Center.X / 16;
        var centerY = (int)player.Center.Y / 16;

        Lighting.AddLight(centerX, centerY, 0.4f, 0.4f, 0.1f);
    }


    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 8)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 8)
            .AddTile(TileID.Anvils)
            .Register();
    }
}