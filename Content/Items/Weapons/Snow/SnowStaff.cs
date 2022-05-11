using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Weapons.Snow
{
    public class SnowStaff : YggdrasilItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Snow Staff");
            Tooltip.SetDefault("it's made out of snow!");
            Item.staff[Item.type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.SnowBallFriendly;
            Item.shootSpeed = 10f;
            
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.SnowBlock, 25)
            .Register();
    }
}
