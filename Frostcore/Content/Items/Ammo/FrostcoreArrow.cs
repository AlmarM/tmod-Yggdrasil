using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.Frostcore.Content.Projectiles;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Frostcore.Content.Items.Ammo;

public class FrostcoreArrow : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Arrow");
        Tooltip.SetDefault("Apply Frostburn on hit");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(0, 0, 0, 4);

        Item.maxStack = 999;

        Item.damage = 10;
        Item.knockBack = 0;
        Item.ammo = AmmoID.Arrow;

        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;

        Item.shoot = ModContent.ProjectileType<FrostcoreArrowProjectile>();
        Item.shootSpeed = 5f;
    }

    public override void AddRecipes() => CreateRecipe(10)
        .AddIngredient<FrostcoreBar>(1)
        .AddIngredient<NordicWood>(5)
        .Register();
}