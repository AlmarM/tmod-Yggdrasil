using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class LunarMemorial : RuneTablet
{
    private const int NebulaExplosionProjectileCount = 3;
    private const int SolarExplosionProjectileCount = 10;
    private const int VortexxplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<LunarMemorialNormalProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Lunar Memorial");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 35;
        Item.useTime = 11;
        Item.useAnimation = 11;
        Item.knockBack = 5;
        Item.crit = 5;
        Item.value = Item.sellPrice(0, 5);
        Item.rare = ItemRarityID.Lime;
    }

    protected override void OnFocusActivated(Player player)
    {
        var projectileId = ModContent.ProjectileType<LunarMemorialNebulaProjectile>();
        CreateCircleExplosion(NebulaExplosionProjectileCount, Item, player, projectileId);

        projectileId = ModContent.ProjectileType<LunarMemorialSolarProjectile>();
        CreateCircleExplosion(SolarExplosionProjectileCount, Item, player, projectileId);

        projectileId = ModContent.ProjectileType<LunarMemorialVortexProjectile>();
        CreateCircleExplosion(VortexxplosionProjectileCount, Item, player, projectileId, 12);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 12; // The number of projectiles.

        runemasterPlayer.Insanity++;

        for (int i = 0; i < NumProjectiles; i++)
        {
            Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
            float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 28);
            Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 14);

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
        focusLine += "Releases projectiles from every facet of the lunar power";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.FragmentNebula, 5)
        .AddIngredient(ItemID.FragmentVortex, 5)
        .AddIngredient(ItemID.FragmentStardust, 5)
        .AddIngredient(ItemID.FragmentSolar, 5)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
}