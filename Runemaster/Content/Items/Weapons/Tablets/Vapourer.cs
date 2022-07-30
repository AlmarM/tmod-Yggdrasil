using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class Vapourer : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<VapourerProjectile>();

    protected override int ProjectileCount => 10;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Vapourer");
        Tooltip.SetDefault("It's the plague!");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 18;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 5);
        Item.rare = ItemRarityID.Lime;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Meadow>()
        .AddIngredient(ItemID.ButterflyDust)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<VapourerProjectileExplosion>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases homing projectiles that will weaken targets");
    }
}