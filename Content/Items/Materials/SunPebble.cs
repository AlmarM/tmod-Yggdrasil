using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class SunPebble : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sun Pebble");
        Tooltip.SetDefault("A fragment of the sun");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.sellPrice(gold: 5);
    }
}