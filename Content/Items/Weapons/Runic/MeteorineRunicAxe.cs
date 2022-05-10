using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;
using Yggdrasil.Content.Tiles.Furniture;


namespace Yggdrasil.Content.Items.Weapons.Runic;

public class MeteorineRunicAxe : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Meteorite Axe");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 17;
        Item.crit = 7;
        Item.knockBack = 7;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 27);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 1));
        AddEffect(new InflictBuffEffect(1, BuffID.OnFire, 1, "OnFire", 0.25f, true));
        AddEffect(new FlatRunicDamageEffect(2, 2));
        AddEffect(new InflictBuffEffect(2, BuffID.Frostburn, 2, "OnFire", 0.25f, true));
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.MeteoriteBar, 12)
        .AddTile<DvergrForgeTile>()
        .Register();
}