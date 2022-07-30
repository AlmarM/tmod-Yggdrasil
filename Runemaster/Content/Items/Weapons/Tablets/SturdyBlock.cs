using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class SturdyBlock : RuneTablet
{
    private const int BeeExplosionProjectileCount = 10;
    private const int ExplosionProjectilesCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<SturdyBlockProjectile>();

    protected override int ProjectileCount => 10;

    protected override float AttackConeSize => 6f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Sturdy Block");
        Tooltip.SetDefault("That's really heavy");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 22;
        Item.useTime = 13;
        Item.useAnimation = 13;
        Item.knockBack = 4;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 7);
        Item.rare = ItemRarityID.Orange;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<HoneyGlazedStone>()
        .AddIngredient<SturdyLeaf>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(BeeExplosionProjectileCount, Item, player, ProjectileID.Bee, 1f);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }

        int projectileId = ModContent.ProjectileType<SturdyBlockProjectileSeed>();

        indexes = CreateCircleExplosion(ExplosionProjectilesCount, Item, player, projectileId);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of homing poison seeds and bees");
    }
}