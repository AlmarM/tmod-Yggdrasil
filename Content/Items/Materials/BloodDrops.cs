using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class BloodDrops : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blood Drops");
        Tooltip.SetDefault("It's a bit gross");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.White;
    }

}