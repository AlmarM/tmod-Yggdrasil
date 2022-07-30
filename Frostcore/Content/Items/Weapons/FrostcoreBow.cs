using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.Frostcore.Content.Projectiles;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Frostcore.Content.Items.Weapons;

public class FrostcoreBow : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Bow");
        Tooltip.SetDefault("It's really cold!" +
                           "\nWooden Arrows turn into FrostCore Arrows");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 15;
        Item.noMelee = true;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useAmmo = AmmoID.Arrow;
        Item.knockBack = 4;
        Item.useTurn = false;
        Item.value = Item.sellPrice(silver: 23);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item5;
        Item.autoReuse = true;
        Item.shootSpeed = 4.25f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
        Vector2 velocity, int type, int damage, float knockback)
    {
        if (type == ProjectileID.WoodenArrowFriendly)
        {
            type = ModContent.ProjectileType<FrostcoreArrowProjectile>();
        }

        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback,
            player.whoAmI);
        return false;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreBar>(8)
        .AddIngredient<NordicWood>(5)
        .AddTile(TileID.Anvils)
        .Register();
}