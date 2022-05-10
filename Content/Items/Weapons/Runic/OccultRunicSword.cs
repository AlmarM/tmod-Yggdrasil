using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class OccultRunicSword : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Occult Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 25;
        Item.crit = 0;
        Item.knockBack = 5;
        Item.value = Item.sellPrice(0, 0, 50);
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
    }

    protected override void AddEffects()
    {
        AddEffect(new AutoReuseEffect(1));
        AddEffect(new AttackSpeedEffect(1, 0.25f));
        AddEffect(new FlatRunicDamageEffect(3, 2));
        AddEffect(new RunicCritChanceEffect(3, 5));
    }


    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>()
        .AddTile<DvergrForgeTile>()
        .Register();

}