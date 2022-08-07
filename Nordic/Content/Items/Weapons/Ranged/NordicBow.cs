﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Ores;
using Yggdrasil.Content.Items.Weapons.Ranged;
using Yggdrasil.Frostcore.Content.Projectiles;
using Yggdrasil.Nordic.Content.Items.Blocks;
using Yggdrasil.Nordic.Content.Projectiles;

namespace Yggdrasil.Nordic.Content.Items.Weapons.Ranged;

public class NordicBow : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Glacier Bow");
        Tooltip.SetDefault("\nWooden Arrows turn into Frostcore Arrows" +
                           "\nFire 3 arrows for the cost of one" +
                           "\nMight thrown homing nordic ball");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 80;
        Item.noMelee = true;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useAmmo = AmmoID.Arrow;
        Item.knockBack = 4;
        Item.useTurn = false;
        Item.value = Item.sellPrice(gold: 10);
        Item.rare = ItemRarityID.Yellow;
        Item.UseSound = SoundID.Item5;
        Item.autoReuse = true;
        Item.shootSpeed = 10f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        if (Main.rand.NextBool(4))
        {
            Projectile.NewProjectile(source, position.X, position.Y - 6, velocity.X, velocity.Y,
                ModContent.ProjectileType<NordicBallExplosionProjectile>(), damage, knockback, player.whoAmI);
        }

        if (type == ProjectileID.WoodenArrowFriendly)
        {
            type = ModContent.ProjectileType<FrostcoreArrowProjectile>();
        }

        Projectile.NewProjectile(source, position.X, position.Y - 6, velocity.X, velocity.Y, type, damage, knockback,
            player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback,
            player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y + 6, velocity.X, velocity.Y, type, damage, knockback,
            player.whoAmI);

        return false;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<GlacierBow>()
        .AddIngredient<ColdIronBar>(5)
        .AddIngredient<NordicWood>(10)
        .AddTile(TileID.MythrilAnvil)
        .Register();
}