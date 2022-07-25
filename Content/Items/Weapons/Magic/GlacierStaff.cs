using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.Magic;
using Yggdrasil.Frostcore.Content.Items.Weapons;

namespace Yggdrasil.Content.Items.Weapons.Magic;

public class GlacierStaff : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Glacier Staff");
        Tooltip.SetDefault("That's a cold one" +
                           "\nThrows 2 homings ice chunks that applies Frostburn");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 50;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 12;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 3;
        Item.crit = 0;
        Item.value = Item.sellPrice(gold: 5);
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = false;
        Item.shoot = ModContent.ProjectileType<GlacierStaffProjectile>();
        Item.shootSpeed = 8f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
        Vector2 velocity, int type, int damage, float knockback)
    {
        const int numProjectiles = 2; // The number of projectiles that this gun will shoot.

        for (int i = 0; i < numProjectiles; i++)
        {
            Vector2 mouseToPlayer = Main.MouseWorld - player.Center;
            float rotation = (mouseToPlayer.ToRotation() - MathHelper.Pi / 16);
            Vector2 speed = Main.rand.NextVector2Unit(rotation, MathHelper.Pi / 8);

            Projectile.NewProjectile(source, player.Center, speed * 10, type, damage, knockback,
                player.whoAmI);
        }

        return false;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreTome>()
        .AddIngredient<GlacierShards>(10)
        .AddTile(TileID.MythrilAnvil)
        .Register();
}