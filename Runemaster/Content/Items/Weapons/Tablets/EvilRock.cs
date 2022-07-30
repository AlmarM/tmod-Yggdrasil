using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class EvilRock : RuneTablet
{
    private const int ExplosionProjectileCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<EvilRockProjectile>();

    protected override int ProjectileCount => 5;

    protected override float AttackConeSize => 6f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Evil Rock");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 8;
        Item.knockBack = 2;
        Item.crit = 1;
        Item.value = Item.sellPrice(0, 0, 30);
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.CrimtaneBar, 5)
            .AddTile<DvergrForgeTile>()
            .Register();

        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.DemoniteBar, 5)
            .AddTile<DvergrForgeTile>()
            .Register();
    }

    protected override void OnFocusActivated(Player player)
    {
        var projectileId = ModContent.ProjectileType<EvilRockProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of projectiles around you");
    }
}