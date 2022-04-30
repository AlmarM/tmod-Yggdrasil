using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Content.Items.Weapons
{
    public class SnowBow : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Bow");
            Tooltip.SetDefault("It's made out of snow!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Ranged;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.crit = 0;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 8f;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.SnowBlock, 25)
            .Register();
    }
}
