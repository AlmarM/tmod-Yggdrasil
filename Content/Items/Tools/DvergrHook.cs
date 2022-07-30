using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles.Tools;

namespace Yggdrasil.Content.Items.Tools;

public class DvergrHook : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dvergr Hook");
        Tooltip.SetDefault("Striking tiles will briefly boost your damage reduction");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.AmethystHook);
        Item.shootSpeed = 18f;
        Item.shoot = ModContent.ProjectileType<DvergrHookProjectile>();
    }

}