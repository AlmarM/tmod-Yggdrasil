using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class SturdyLeaf : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sturdy Leaf");
        Tooltip.SetDefault("I would not bite that");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Lime;
        Item.value = Item.sellPrice(gold: 1);
    }
}