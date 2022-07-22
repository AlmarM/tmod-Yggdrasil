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

public class HoneyGlazedStone : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<HoneyStoneProjectile>();

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Honey Glazed Stone");
        Tooltip.SetDefault("Drenches the owner in honey");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 10;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.Orange;
    }

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.Bee, 1f);
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
        const int NumProjectiles = 7; // The number of projectiles.

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

    public override void HoldItem(Player player)
    {
        base.HoldItem(player);

        player.AddBuff(BuffID.Honey, 2);
    }

    protected override List<string> GetRunicEffectDescriptions()
    {
        List<string> descriptions = base.GetRunicEffectDescriptions();

        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");

        string focusLine = $"{focusColored}: ";
        focusLine += "Releases bees and heal the user. The more insanity, the more the heal!";

        descriptions.Add(focusLine);

        return descriptions;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.HoneyComb)
        .AddTile<DvergrForgeTile>()
        .Register();
}