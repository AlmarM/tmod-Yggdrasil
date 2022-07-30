using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Weapons.Melee;

public class OccultSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Occult Sword");
        Tooltip.SetDefault("Is that made out of bones?");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 26;
        Item.DamageType = DamageClass.Melee;
        Item.useTime = 18;
        Item.useAnimation = 18;
        Item.knockBack = 3;
        Item.crit = 1;
        Item.value = Item.sellPrice(gold: 1);
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.useStyle = ItemUseStyleID.Swing;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>(15)
        .AddTile(TileID.Anvils)
        .Register();
}