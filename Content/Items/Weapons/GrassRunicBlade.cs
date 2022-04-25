using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Items;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class GrassRunicBlade : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        // @todo add effect description?
        DisplayName.SetDefault("Grass Runic Blade");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 4;
        Item.knockBack = 5;
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