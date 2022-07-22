﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class OccultTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<OccultTabletProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Occult Tablet");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 8;
        Item.knockBack = 2;
        Item.crit = 2;
        Item.value = Item.sellPrice(0, 0, 50);
        Item.rare = ItemRarityID.Green;
    }

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.Bone);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }
        
        HealByInsanity(player, 2f);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 6; // The number of projectiles.

        runemasterPlayer.Insanity++;

        for (int i = 0; i < NumProjectiles; i++)
        {
            Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
            float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 12);
            Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 6);

            float SpeedMultiplier = runemasterPlayer.RunicProjectileSpeedMultiplyer;

            Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback,
                player.whoAmI);
        }

        return false;
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "Releases a bunch of bones";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient<OccultShard>(10)
        .AddTile<DvergrForgeTile>()
        .Register();
}