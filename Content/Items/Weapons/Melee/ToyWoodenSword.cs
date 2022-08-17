using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Weapons.Melee;

public class ToyWoodenSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Toy Wooden Sword");
        Tooltip.SetDefault("Really good for carpal tunnels");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 6;
        Item.DamageType = DamageClass.Melee;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.knockBack = 4;
        Item.crit = 0;
        Item.value = Item.sellPrice(copper: 25);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.useStyle = ItemUseStyleID.Swing;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 10)
        .AddTile(TileID.WorkBenches)
        .Register();
}