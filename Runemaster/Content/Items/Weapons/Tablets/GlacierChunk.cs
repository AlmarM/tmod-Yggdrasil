using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class GlacierChunk : RuneTablet
{
    private const int ExplosionProjectileCount = 8;

    protected override int ProjectileId => ModContent.ProjectileType<GlacierChunkProjectile>();

    protected override int ProjectileCount => 9;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Glacier Chunk");
        Tooltip.SetDefault("Absolute zero and stuff");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 15;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1, 25);
        Item.rare = ItemRarityID.LightRed;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostTablet>()
        .AddIngredient<GlacierShards>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.BallofFrost);

        player.AddBuff(ModContent.BuffType<GlacierBarrier>(), TimeUtils.SecondsToTicks(5));
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of frost balls around you applies Glacier Barrier buff");
    }
}