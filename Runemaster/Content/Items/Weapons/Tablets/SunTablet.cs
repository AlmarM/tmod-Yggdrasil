using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class SunTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 8;

    protected override int ProjectileId => ModContent.ProjectileType<SunTabletProjectile>();

    protected override int ProjectileCount => 10;

    protected override float AttackConeSize => 14f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Sun Tablet");
        Tooltip.SetDefault("That one's heavy");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 25;
        Item.useTime = 13;
        Item.useAnimation = 13;
        Item.knockBack = 4;
        Item.crit = 4;
        Item.value = Item.sellPrice(0, 15);
        Item.rare = ItemRarityID.Yellow;
    }

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.BoulderStaffOfEarth);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }

        player.AddBuff(ModContent.BuffType<TheSunBuff>(), TimeUtils.SecondsToTicks(5));
    }

    protected override void OnConeProjectileCreated(IEntitySource source, Vector2 position, Vector2 velocity, int type,
        int damage, float knockback, int owner, int index)
    {
        if (!Main.rand.NextBool(50))
        {
            return;
        }

        velocity.Normalize();

        Projectile.NewProjectile(source, position, velocity * 10, ProjectileID.BoulderStaffOfEarth, damage,
            knockback, owner);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases an explosion of boulders");
        block.AddLine($"{focusColored}: Applies The Sun buff");
    }
}