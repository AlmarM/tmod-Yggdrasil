using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Items.Weapons;

public class TitaniumRunicBlade : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Titanium Runic Blade");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.autoReuse = true;
        Item.damage = 65;
        Item.crit = 15;
        Item.knockBack = 3;
        Item.value = Item.buyPrice(0, 3, 22);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.TitaniumBar, 8)
            .AddIngredient(ItemID.SilverBar, 10)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.TitaniumBar, 8)
            .AddIngredient(ItemID.TungstenBar, 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}