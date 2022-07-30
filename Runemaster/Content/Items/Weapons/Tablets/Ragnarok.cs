using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class Ragnarok : RuneTablet
{
    private const int ExplosionProjectileCount = 5;

    protected override int ProjectileId => ModContent.ProjectileType<RagnarokProjectile>();

    protected override int ProjectileCount => 15;

    protected override float AttackConeSize => 14f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(34, 6));

        DisplayName.SetDefault("Ragnarök");
        Tooltip.SetDefault("The death of Baldr was the beginning of the end");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 60;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.knockBack = 5;
        Item.crit = 6;
        Item.value = Item.sellPrice(0, 15);
        Item.rare = ItemRarityID.Red;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
        Vector2 velocity, int type, int damage, float knockback)
    {
        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        var speed = runemasterPlayer.RunicProjectileSpeedMultiplier * 2f;

        CreateConeAttack(source, player, speed, type, damage, knockback);

        if (Main.rand.NextBool(5))
        {
            int projectileId = ModContent.ProjectileType<RagnarokProjectileLazerShot>();
            Projectile.NewProjectile(source, player.Center, velocity, projectileId, damage * 3, knockback,
                player.whoAmI);
        }

        return false;
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<RagnarokProjectileExplosion>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Bring the end of the world upon your enemies");
    }
}