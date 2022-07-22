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

public class ShinyTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 9;

    protected override int ProjectileId => ModContent.ProjectileType<ShinyTabletProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Shiny Tablet");
        Tooltip.SetDefault("Generates light");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 7;
        Item.knockBack = 1;
        Item.crit = 1;
        Item.value = Item.sellPrice(0, 0, 18);
        Item.rare = ItemRarityID.White;
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<ShinyTabletProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 3; // The number of projectiles.

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

    public override void HoldItem(Player player)
    {
        base.HoldItem(player);

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        var centerX = (int)runemasterPlayer.Player.Center.X / 16;
        var centerY = (int)runemasterPlayer.Player.Center.Y / 16;

        Lighting.AddLight(centerX, centerY, 0.4f, 0.4f, 0.1f);
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "Releases a small explosion of projectiles around you & Shows the location of treasure and ore";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.GoldBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.PlatinumBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}