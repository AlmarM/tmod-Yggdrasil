using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class FrostTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 4;

    protected override int ProjectileId => ModContent.ProjectileType<FrostTabletProjectile>();

    protected override int ProjectileCount => 4;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Frost Tablet");
        Tooltip.SetDefault("By Odin that's cold!");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 8;
        Item.knockBack = 2;
        Item.crit = 1;
        Item.value = Item.sellPrice(0, 0, 23);
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient<FrostcoreBar>(5)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.BallofFrost);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a small explosion of frost balls around you");
    }
}