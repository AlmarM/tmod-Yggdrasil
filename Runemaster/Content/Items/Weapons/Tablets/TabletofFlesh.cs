using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class TabletofFlesh : RuneTablet
{
    private const int ExplosionProjectileCount = 12;

    protected override int ProjectileId => ModContent.ProjectileType<TabletofFleshProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Tablet of Flesh");
        Tooltip.SetDefault("Are these things moving?");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 12;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1, 25);
        Item.rare = ItemRarityID.LightRed;
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<TabletofFleshProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
        
        player.AddBuff(ModContent.BuffType<SuperHPRegen>(), TimeUtils.SecondsToTicks(5));
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 9; // The number of projectiles.

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
        focusLine += "Releases an explosion of projectiles around you and greatly increases life regeneration";

        descriptions.Add(focusLine);

        return descriptions;
    }

    // Dropped by WoF
}