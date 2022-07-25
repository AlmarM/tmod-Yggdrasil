using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Projectiles.Melee;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Frostcore.Content.Items.Weapons;

public class FrostcoreSpear : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Spear");
        Tooltip.SetDefault("50% chance to frostburn target for 3 sec");

        // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
        ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
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
        Item.shoot = ModContent.ProjectileType<FrostCoreSpearProjectile>();
        Item.value = Item.sellPrice(silver: 23);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreBar>(8)
        .AddIngredient<NordicWood>(5)
        .AddTile(TileID.Anvils)
        .Register();
}