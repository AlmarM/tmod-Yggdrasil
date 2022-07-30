using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles.Melee;

namespace Yggdrasil.Content.Items.Weapons.Melee;

public class VikingSpear : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Spear");
        Tooltip.SetDefault("To reach over the shield wall");

        ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 34;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 4;
        Item.crit = 0;
        Item.noUseGraphic = true;
        Item.DamageType = DamageClass.Melee;
        Item.noMelee = true;
        Item.shootSpeed = 3.5f;
        Item.shoot = ModContent.ProjectileType<VikingSpearProjectile>();
        Item.value = Item.sellPrice(silver: 80);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }
}