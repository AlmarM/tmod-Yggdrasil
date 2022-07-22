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

public class Ragnarok : RuneTablet
{
    private const int ExplosionProjectileCount = 5;

    protected override int ProjectileId => ModContent.ProjectileType<RagnarokProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(34, 6));

        DisplayName.SetDefault("Ragnarök");
        Tooltip.SetDefault("The death of Baldr was the beginning of the end");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.damage = 60;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.knockBack = 5;
        Item.crit = 6;
        Item.value = Item.sellPrice(0, 15);
        Item.rare = ItemRarityID.Red;
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<RagnarokProjectileExplosion>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
        Vector2 velocity, int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 15; // The number of projectiles.

        runemasterPlayer.Insanity++;

        for (int i = 0; i < NumProjectiles; i++)
        {
            Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
            float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 28);
            Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 14);

            float SpeedMultiplier =
                runemasterPlayer.RunicProjectileSpeedMultiplyer *
                2; // Times 2 cuz that's a badass weapon so projectiles reach farther

            Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback,
                player.whoAmI);
        }

        // 1/5 chances of shooting a rune projectile when attacking
        var Type = ModContent.ProjectileType<RagnarokProjectileLazerShot>();
        if (Main.rand.NextBool(5))
        {
            Projectile.NewProjectile(source, Main.LocalPlayer.Center, velocity, Type, damage * 3, knockback,
                player.whoAmI);
        }

        return false;
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "Bring the end of the world upon your enemies";

        descriptions.Add(focusLine);

        return descriptions;
    }

    //Dropped by Moonlord
}