using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class HellishTablet : RuneTablet
{
    private const int FireExplosionProjectileCount = 10;
    private const int HellishExplosionProjectileCount = 5;

    protected override int ProjectileId => ModContent.ProjectileType<HellishTabletProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        DisplayName.SetDefault("Tablet of the Underworld");
        Tooltip.SetDefault("That one's pretty hot");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.damage = 11;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.Orange;
    }

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(FireExplosionProjectileCount, Item, player, ProjectileID.BallofFire);
        
        var projectileId = ModContent.ProjectileType<HellishTabletProjectile>();
        CreateCircleExplosion(HellishExplosionProjectileCount, Item, player, projectileId);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 8; // The number of projectiles.

        runemasterPlayer.Insanity++;

        for (int i = 0; i < NumProjectiles; i++)
        {
            Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
            float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 16);
            Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 8);

            float SpeedMultiplier = runemasterPlayer.RunicProjectileSpeedMultiplyer;

            Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback,
                player.whoAmI);
        }

        if (Main.rand.NextFloat() < .1f)
        {
            // @todo clean up in the future
            var x = player.Center.X;
            var y = player.Center.Y;

            var direction = Main.MouseWorld - player.Center;
            direction.Normalize();

            var speed = 6f;
            float speedX = direction.X * speed;
            float speedY = direction.Y * speed;
            int projectileType = ProjectileID.BallofFire;

            Projectile.NewProjectile(null, x, y, speedX, speedY, projectileType, damage, 0,
                player.whoAmI);
        }

        return false;
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "Releases an explosion of projectiles and fireballs";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.Obsidian, 20)
        .AddIngredient(ItemID.HellstoneBar, 6)
        .AddTile<DvergrForgeTile>()
        .Register();
}