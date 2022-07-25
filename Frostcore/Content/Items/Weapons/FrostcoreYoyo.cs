using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Projectiles.Yoyo;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Frostcore.Content.Items.Weapons;

public class FrostcoreYoyo : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Yoyo");
        Tooltip.SetDefault("50% chance to frostburn target for 3 sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.WoodYoyo);
        Item.damage = 15;
        Item.value = Item.sellPrice(silver: 23);
        Item.rare = ItemRarityID.Blue;
        Item.knockBack = 3;
        Item.channel = true;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 28;
        Item.useTime = 25;
        Item.shoot = ModContent.ProjectileType<FrostcoreYoyoProjectile>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NordicWood>(5)
        .AddIngredient<FrostcoreBar>(5)
        .AddTile(TileID.Anvils)
        .Register();
}