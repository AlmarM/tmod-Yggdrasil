using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class PalladiumRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Palladium Runic Hamaxe");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 40;
        Item.crit = 10;
        Item.knockBack = 5;
		Item.axe = 15;
		Item.hammer = 85;
		Item.value = Item.buyPrice(0, 1, 38, 0);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.PalladiumBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
		

}