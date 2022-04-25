using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Items;

namespace Yggdrasil.Content.Items.Weapons;

public class LuminiteRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Luminite Runic Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.autoReuse = true;
        Item.damage = 160;
        Item.crit = 5;
        Item.knockBack = 7;
        Item.value = Item.buyPrice(0, 8);
        Item.rare = ItemRarityID.Red;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.LunarBar, 20) // Luminite Bar
        .AddTile(TileID.Anvils)
        .Register();
}