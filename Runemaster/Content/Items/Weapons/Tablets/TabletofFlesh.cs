using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class TabletofFlesh : RuneTablet
{
    private const int ExplosionProjectileCount = 12;

    protected override int ProjectileId => ModContent.ProjectileType<TabletofFleshProjectile>();

    protected override int ProjectileCount => 9;

    protected override float AttackConeSize => 6f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Tablet of Flesh");
        Tooltip.SetDefault("Are these things moving?");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 12;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1, 25);
        Item.rare = ItemRarityID.LightRed;
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<TabletofFleshProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);

        player.AddBuff(ModContent.BuffType<SuperHPRegen>(), TimeUtils.SecondsToTicks(5));
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of projectiles around you");
        block.AddLine($"{focusColored}: Greatly increases life regeneration");
    }
}