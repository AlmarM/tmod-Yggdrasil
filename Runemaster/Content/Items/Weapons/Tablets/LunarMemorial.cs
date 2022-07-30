using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class LunarMemorial : RuneTablet
{
    private const int NebulaExplosionProjectileCount = 3;
    private const int SolarExplosionProjectileCount = 10;
    private const int VortexxplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<LunarMemorialNormalProjectile>();

    protected override int ProjectileCount => 12;

    protected override float AttackConeSize => 14f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Lunar Memorial");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 35;
        Item.useTime = 11;
        Item.useAnimation = 11;
        Item.knockBack = 5;
        Item.crit = 5;
        Item.value = Item.sellPrice(0, 5);
        Item.rare = ItemRarityID.Lime;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.FragmentNebula, 5)
        .AddIngredient(ItemID.FragmentVortex, 5)
        .AddIngredient(ItemID.FragmentStardust, 5)
        .AddIngredient(ItemID.FragmentSolar, 5)
        .AddTile(TileID.LunarCraftingStation)
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        var projectileId = ModContent.ProjectileType<LunarMemorialNebulaProjectile>();
        CreateCircleExplosion(NebulaExplosionProjectileCount, Item, player, projectileId);

        projectileId = ModContent.ProjectileType<LunarMemorialSolarProjectile>();
        CreateCircleExplosion(SolarExplosionProjectileCount, Item, player, projectileId);

        projectileId = ModContent.ProjectileType<LunarMemorialVortexProjectile>();
        CreateCircleExplosion(VortexxplosionProjectileCount, Item, player, projectileId, 12);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases projectiles from every facet of the lunar power");
    }
}