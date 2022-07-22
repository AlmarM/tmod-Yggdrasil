using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class FallenNugget : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<FallenNuggetProjectile>();

    protected override int ProjectileCount => 5;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Fallen Nugget");
        Tooltip.SetDefault("Straight out of the stars");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 7;
        Item.knockBack = 2;
        Item.crit = 2;
        Item.value = Item.sellPrice(0, 0, 30);
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.MeteoriteBar, 5)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.BallofFire);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a small explosion of fire balls around you");
    }
}