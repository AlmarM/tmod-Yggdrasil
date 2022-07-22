using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class StoneBlock : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<StoneBlockProjectile>();

    protected override int ProjectileCount => 2;

    protected override float AttackConeSize => 6f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Stone Slab");
        Tooltip.SetDefault("Well, it's a block of stone");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 2;
        Item.knockBack = 1;
        Item.crit = 0;
        Item.value = Item.sellPrice(0, 0, 0, 20);
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 5)
        .AddTile(TileID.WorkBenches)
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<StoneBlockProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a small explosion of projectiles around you");
    }
}