using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.Yoyo;

namespace Yggdrasil.Content.Items.Weapons.FrostCore
{
    public class FrostcoreYoyo : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frostcore Yoyo");
            Tooltip.SetDefault("50% chance to frostburn target for 3 sec");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodYoyo);
            Item.damage = 15;
            Item.value = Item.sellPrice(0, 0, 23, 0);
            Item.rare = ItemRarityID.Blue;
            Item.knockBack = 3;
            Item.channel = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 28;
            Item.useTime = 25;
            Item.shoot = ModContent.ProjectileType<FrostcoreYoyoProjectile>();
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<NordicWood>(5)
            .AddIngredient<FrostCoreBar>(5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
