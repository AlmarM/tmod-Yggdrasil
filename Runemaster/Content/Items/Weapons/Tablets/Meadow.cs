using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class Meadow : RuneTablet
{
    private const int ExplosionProjectileCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<MeadowProjectile>();

    protected override int ProjectileCount => 7;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Meadow");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 9;
        Item.knockBack = 3;
        Item.crit = 2;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.Orange;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.Stinger, 5)
        .AddIngredient(ItemID.RichMahogany, 15)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<MeadowProjectileExplosion>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of projectiles that will slow down targets");
    }
}