using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class FrostCoreRunicAxe : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic FrostCore Axe");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.autoReuse = false;
        Item.damage = 20;
        Item.crit = 6;
        Item.knockBack = 6;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 23);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(8)
        .AddTile(TileID.Anvils)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 1));
        AddEffect(new InflictBuffEffect(1, BuffID.Frostburn, 1, "Frostburn", 0.5f, true));
        AddEffect(new FlatRunicDamageEffect(2, 1));
        AddEffect(new RunicCritChanceEffect(2, 2));
        AddEffect(new InflictBuffEffect(2, BuffID.Frostburn, 2, "Frostburn", 0.25f, true));
    }
}