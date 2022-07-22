using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class ShinyTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 9;

    protected override int ProjectileId => ModContent.ProjectileType<ShinyTabletProjectile>();

    protected override int ProjectileCount => 3;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Shiny Tablet");
        Tooltip.SetDefault("Generates light");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 7;
        Item.knockBack = 1;
        Item.crit = 1;
        Item.value = Item.sellPrice(0, 0, 18);
        Item.rare = ItemRarityID.White;
    }

    public override void HoldItem(Player player)
    {
        base.HoldItem(player);

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        var centerX = (int)runemasterPlayer.Player.Center.X / 16;
        var centerY = (int)runemasterPlayer.Player.Center.Y / 16;

        Lighting.AddLight(centerX, centerY, 0.4f, 0.4f, 0.1f);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.GoldBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient<StoneBlock>()
            .AddIngredient(ItemID.PlatinumBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }

    protected override void OnFocusActivated(Player player)
    {
        int projectileId = ModContent.ProjectileType<ShinyTabletProjectile>();
        CreateCircleExplosion(ExplosionProjectileCount, Item, player, projectileId);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases a small explosion of projectiles around you");
        block.AddLine($"{focusColored}: Shows the location of treasure and ore");
    }
}