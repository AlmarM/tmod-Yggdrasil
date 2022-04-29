using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class ChlorophyteRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Chlorophyte Blade");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.autoReuse = false;
        Item.damage = 65;
        Item.crit = 5;
        Item.knockBack = 5;
        Item.value = Item.buyPrice(0, 5, 52);
        Item.rare = ItemRarityID.Lime;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        if (Main.rand.NextFloat() < 0.5f)
        {
            target.AddBuff(BuffID.Poisoned, TimeUtils.SecondsToTicks(10));
        }
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.ChlorophyteBar, 10)
        .AddIngredient(ItemID.MeteoriteBar, 5)
        .AddTile(TileID.Anvils)
        .Register();
}