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

public class SunTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 8;

    protected override int ProjectileId => ModContent.ProjectileType<SunTabletProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Sun Tablet");
        Tooltip.SetDefault("That one's heavy");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 25;
        Item.useTime = 13;
        Item.useAnimation = 13;
        Item.knockBack = 4;
        Item.crit = 4;
        Item.value = Item.sellPrice(0, 15);
        Item.rare = ItemRarityID.Yellow;
    }

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.BoulderStaffOfEarth);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }
        
        player.AddBuff(ModContent.BuffType<TheSunBuff>(), TimeUtils.SecondsToTicks(5));
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
        Vector2 velocity, int type, int damage, float knockback)
    {
        // THE ATTACK

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        const int NumProjectiles = 10; // The number of projectiles.
        var Type2 = ProjectileID.BoulderStaffOfEarth;
        runemasterPlayer.Insanity++;

        for (int i = 0; i < NumProjectiles; i++)
        {
            Vector2 MouseToPlayer = Main.MouseWorld - player.Center;
            float Rotation = (MouseToPlayer.ToRotation() - MathHelper.Pi / 28);
            Vector2 Speed = Main.rand.NextVector2Unit(Rotation, MathHelper.Pi / 14);

            float SpeedMultiplier = runemasterPlayer.RunicProjectileSpeedMultiplyer;

            Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * SpeedMultiplier, type, damage, knockback,
                player.whoAmI);

            if (Main.rand.Next(100) < 2)
            {
                Projectile.NewProjectile(source, Main.LocalPlayer.Center, Speed * 10, Type2, damage, knockback,
                    player.whoAmI);
            }
        }

        return false;
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "Releases an explosion of boulders and applies The Sun buff";

        descriptions.Add(focusLine);

        return descriptions;
    }

    //Dropped by Golem
}