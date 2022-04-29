using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Items.Weapons;

public class AdamantiteRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Adamantite Sword");

        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.autoReuse = false;
        Item.damage = 52;
        Item.crit = 5;
        Item.knockBack = 5;
        Item.value = Item.buyPrice(0, 3, 22);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.AdamantiteBar, 10)
        .AddTile(TileID.Anvils)
        .Register();
}