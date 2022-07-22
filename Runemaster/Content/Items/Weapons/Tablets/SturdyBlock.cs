using System.Collections.Generic;
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

public class SturdyBlock : RuneTablet
{
    private const int BeeExplosionProjectileCount = 10;
    private const int ExplosionProjectilesCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<SturdyBlockProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Sturdy Block");
        Tooltip.SetDefault("That's really heavy");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 22;
        Item.useTime = 13;
        Item.useAnimation = 13;
        Item.knockBack = 4;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 7);
        Item.rare = ItemRarityID.Orange;
    }

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(BeeExplosionProjectileCount, Item, player, ProjectileID.Bee, 1f);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }

        int projectileId = ModContent.ProjectileType<SturdyBlockProjectileSeed>();

        indexes = CreateCircleExplosion(ExplosionProjectilesCount, Item, player, projectileId);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 10; // The number of projectiles.

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
        focusLine += "Releases an explosion of homing poison seeds and bees";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<HoneyGlazedStone>()
        .AddIngredient<SturdyLeaf>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}