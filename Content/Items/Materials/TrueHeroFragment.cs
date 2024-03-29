using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria;

namespace Yggdrasil.Content.Items.Materials;

public class TrueHeroFragment : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("True Hero Fragment");
        Tooltip.SetDefault("Fragment of a true hero gear");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.buyPrice(0, 10);
    }

}