using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Misc;

public class SvartalvheimKey : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalvheim Key");
        Tooltip.SetDefault("A key from the dwarven world");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.sellPrice(gold: 5);
    }
}