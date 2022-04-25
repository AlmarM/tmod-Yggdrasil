using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Items;

namespace Yggdrasil.Content.Items.Weapons;

public class PalladiumRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Palladium Runic Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.autoReuse = false;
        Item.damage = 37;
        Item.crit = 4;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 1, 38);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.PalladiumBar, 8)
            .AddIngredient(ItemID.GoldBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PalladiumBar, 8)
            .AddIngredient(ItemID.PlatinumBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}