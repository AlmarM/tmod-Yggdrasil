using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Items.Weapons;

public class ShroomiteRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Shroomite Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 18;
        Item.useAnimation = 18;
        Item.autoReuse = true;
        Item.damage = 80;
        Item.crit = 5;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 6, 45);
        Item.rare = ItemRarityID.Yellow;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.ShroomiteBar, 12)
            .AddIngredient(ItemID.DemoniteBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.ShroomiteBar, 12)
            .AddIngredient(ItemID.CrimtaneBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}