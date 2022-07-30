using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class DevelishPlate : RuneTablet
{
    private const int ExplosionProjectileCount = 12;

    protected override int ProjectileId => ModContent.ProjectileType<DevelishPlateProjectile>();

    protected override int ProjectileCount => 10;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Develish Plate");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 20;
        Item.useTime = 14;
        Item.useAnimation = 14;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 6);
        Item.rare = ItemRarityID.LightPurple;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<HellishTablet>()
        .AddIngredient(ItemID.FireFeather)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        var projectileId = ModContent.ProjectileType<DevelishPlateProjectileExplosion>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of projectiles oiling targets");
    }
}