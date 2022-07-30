using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class JotunTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<JotunTabletProjectile>();

    protected override int ProjectileCount => 9;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Jotun Tablet");
        Tooltip.SetDefault("Made of giants");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 17;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 5);
        Item.rare = ItemRarityID.Pink;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FallenNugget>()
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.CursedFlameFriendly);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a small explosion of cursed flames around you");
    }
}