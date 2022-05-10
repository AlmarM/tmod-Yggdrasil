/*using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class ShinyRunicSpear : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Shiny Spear");

        ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 18;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 4;
        Item.crit = 0;
        Item.noUseGraphic = true;
        Item.DamageType = DamageClass.Melee;
        Item.noMelee = true;
        Item.shootSpeed = 3.5f;
        Item.shoot = ModContent.ProjectileType<ShinyRunicSpearProjectile>();

        Item.value = Item.sellPrice(0, 0, 18, 0);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 8)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 8)
            .AddTile(TileID.Anvils)
            .Register();
    }

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 2));
    }

    
}*/