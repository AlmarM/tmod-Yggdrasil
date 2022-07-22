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

public class JotunTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<JotunTabletProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        DisplayName.SetDefault("Jotun Tablet");
        Tooltip.SetDefault("Made of giants");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.damage = 17;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 5);
        Item.rare = ItemRarityID.Pink;
    }

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.CursedFlameFriendly);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
        Vector2 velocity, int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 9; // The number of projectiles.

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
        focusLine += "Releases a small explosion of crused flames around you";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FallenNugget>()
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}