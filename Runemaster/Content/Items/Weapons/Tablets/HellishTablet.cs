using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class HellishTablet : RuneTablet
{
    private const int FireExplosionProjectileCount = 10;
    private const int HellishExplosionProjectileCount = 5;

    protected override int ProjectileId => ModContent.ProjectileType<HellishTabletProjectile>();

    protected override int ProjectileCount => 8;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Tablet of the Underworld");
        Tooltip.SetDefault("That one's pretty hot");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.shootSpeed = 6f;
        Item.damage = 11;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.Orange;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.Obsidian, 20)
        .AddIngredient(ItemID.HellstoneBar, 6)
        .AddTile<DvergrForgeTile>()
        .Register();

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        base.Shoot(player, source, position, velocity, type, damage, knockback);

        if (Main.rand.NextBool(10))
        {
            Projectile.NewProjectile(source, player.Center, velocity, ProjectileID.BallofFire, damage, knockback,
                player.whoAmI);
        }

        return false;
    }

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(FireExplosionProjectileCount, Item, player, ProjectileID.BallofFire);

        var projectileId = ModContent.ProjectileType<HellishTabletProjectile>();
        CreateCircleExplosion(HellishExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of projectiles and fireballs");
    }
}