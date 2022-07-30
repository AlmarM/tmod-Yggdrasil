using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class OccultTablet : RuneTablet
{
    private const int ExplosionProjectileCount = 10;

    protected override int ProjectileId => ModContent.ProjectileType<OccultTabletProjectile>();

    protected override int ProjectileCount => 6;

    protected override float AttackConeSize => 6f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Occult Tablet");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 8;
        Item.knockBack = 2;
        Item.crit = 2;
        Item.value = Item.sellPrice(0, 0, 50);
        Item.rare = ItemRarityID.Green;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient<OccultShard>(10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        int[] indexes = CreateCircleExplosion(ExplosionProjectileCount, Item, player, ProjectileID.Bone);
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
        block.AddLine($"{focusColored}: Releases a bunch of bones");
    }
}