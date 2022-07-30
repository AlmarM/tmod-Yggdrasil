using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class RuneStone : RuneTablet
{
    private const int ExplosionProjectileCount = 8;

    protected override int ProjectileId => ModContent.ProjectileType<RuneStoneProjectile>();

    protected override int ProjectileCount => 3;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Rune Stone");
        Tooltip.SetDefault("Got a little bit of magic in it");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 4;
        Item.knockBack = 1;
        Item.crit = 0;
        Item.value = Item.sellPrice(0, 0, 5, 40);
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.LeadBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.IronBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<RuneStoneProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a small explosion of projectiles around you");
    }
}