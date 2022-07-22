using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class SpikyBlock : RuneTablet
{
    private const int ExplosionProjectileCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<SpikyBlockProjectile>();

    protected override int ProjectileCount => 6;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Spiky Block");
        Tooltip.SetDefault("Watch your fingers");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 8;
        Item.knockBack = 2;
        Item.crit = 2;
        Item.value = Item.sellPrice(0, 0, 55);
        Item.rare = ItemRarityID.Green;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.SpikyBall, 50)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.SpikyBall);

        player.AddBuff(ModContent.BuffType<SpikyBuff>(), TimeUtils.SecondsToTicks(5));
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a bunch of spiky balls");
        block.AddLine($"{focusColored}: Applies Spiky buff");
    }
}