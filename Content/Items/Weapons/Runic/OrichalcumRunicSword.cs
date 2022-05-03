using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class OrichalcumRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Orichalcum Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 23;
        Item.autoReuse = false;
        Item.damage = 45;
        Item.crit = 4;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 2, 53);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.OrichalcumBar, 8)
            .AddIngredient(ItemID.IronBar, 10)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.OrichalcumBar, 8)
            .AddIngredient(ItemID.LeadBar, 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}