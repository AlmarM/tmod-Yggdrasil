﻿using System.Collections.Generic;
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

public class BloodySlab : RuneTablet
{
    protected override int ProjectileId => ModContent.ProjectileType<BloodySlabProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Bloody Slab");
        Tooltip.SetDefault("Has a chance to heal on hit");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 7;
        Item.knockBack = 2;
        Item.crit = 1;
        Item.value = Item.sellPrice(0, 0, 25);
        Item.rare = ItemRarityID.Blue;
    }

    protected override void OnFocusActivated(Player player)
    {
        HealByInsanity(player);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 4; // The number of projectiles.

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

        return false;
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "The more insanity, the more the heals!";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.BloodMoonStarter) //Bloody Tear
        .AddTile<DvergrForgeTile>()
        .Register();
}