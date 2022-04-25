using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class GrassRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        // @todo add effect description?
        DisplayName.SetDefault("Grass Runic Axe");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 21;
        Item.crit = 10;
        Item.knockBack = 6;
        Item.axe = 14;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        if (Main.rand.NextFloat() < 0.25f)
        {
            target.AddBuff(BuffID.Poisoned, TimeUtils.SecondsToTicks(5));
        }
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.Stinger, 15)
        .AddIngredient(ItemID.JungleSpores, 15)
        .AddTile(TileID.Anvils)
        .Register();
}