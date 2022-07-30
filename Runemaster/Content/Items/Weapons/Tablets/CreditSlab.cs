using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class CreditSlab : RuneTablet
{
    private const int ExplosionProjectileCount = 15;

    protected override int ProjectileId => ModContent.ProjectileType<CreditSlabProjectile>();

    protected override int ProjectileCount => 10;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Credit Slab");
        Tooltip.SetDefault("Well, that was unexpected");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 21;
        Item.useTime = 14;
        Item.useAnimation = 14;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.LightPurple;
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<CreditSlabProjectileExplosion>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of projectiles that make enemies drop more gold");
    }
}