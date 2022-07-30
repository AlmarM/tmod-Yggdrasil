using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class HoneyGlazedStone : RuneTablet
{
    private const int ExplosionProjectileCount = 6;

    protected override int ProjectileId => ModContent.ProjectileType<HoneyStoneProjectile>();

    protected override int ProjectileCount => 7;

    protected override float AttackConeSize => 6f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Honey Glazed Stone");
        Tooltip.SetDefault("Drenches the owner in honey");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 10;
        Item.knockBack = 3;
        Item.crit = 3;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.Orange;
    }

    public override void HoldItem(Player player)
    {
        base.HoldItem(player);

        player.AddBuff(BuffID.Honey, 2);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.HoneyComb)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.Bee, 1f);
        foreach (int index in indexes)
        {
            Main.projectile[index].friendly = true;
            Main.projectile[index].hostile = false;
        }

        HealByInsanity(player, 2f);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: Releases bees and heals the user. The more insanity, the more the heal!");
    }
}