using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class ObsidianRunicSword : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Obsidian Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 35;
        Item.crit = 0;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(4, 5));
        AddEffect(new RunicCritChanceEffect(5, 10));
        AddEffect(new InflictBuffEffect(2, BuffID.OnFire, 3, "OnFire", 1f, true)); //Temporary need to check for half runicpower time
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dustType = 127;
        int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dustType);

        Dust dust = Main.dust[dustIndex];
        dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
        dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HellstoneBar, 20)
        .AddIngredient(ItemID.Obsidian, 20)
        .AddTile(TileID.Anvils)
        .Register();
}