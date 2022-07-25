using Terraria.ID;
using Terraria;

namespace Yggdrasil.Content.Items.Materials;

public class OccultShard : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Occult Shard");
        Tooltip.SetDefault("A piece of evil");
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 2);
    }
}