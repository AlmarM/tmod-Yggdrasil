using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

public class BloodySlab : RuneTablet
{
    protected override int ProjectileId => ModContent.ProjectileType<BloodySlabProjectile>();

    protected override int ProjectileCount => 4;

    protected override float AttackConeSize => 8f;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Bloody Slab");
        Tooltip.SetDefault("Has a chance to heal on hit");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.damage = 7;
        Item.knockBack = 2;
        Item.crit = 1;
        Item.value = Item.sellPrice(0, 0, 25);
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<StoneBlock>()
        .AddIngredient(ItemID.BloodMoonStarter)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void OnFocusActivated(Player player)
    {
        HealByInsanity(player);
    }

    protected override void ModifyFocusTooltipBlock(TooltipBlock block)
    {
        var focusColored = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "Focus");
        block.AddLine($"{focusColored}: The more insanity, the more the heals!");
    }
}