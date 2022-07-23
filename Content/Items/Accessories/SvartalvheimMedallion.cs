using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Accessories;

[AutoloadEquip(EquipType.Neck)]
public class SvartalvheimMedallion : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalvheim Medallion");
        Tooltip.SetDefault("30% increased mining speed" +
                           "\nGenerates Light" +
                           "\nIncreases defense by 5 when underground" +
                           "\nGrants 3% damage reduction when underground");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Yellow;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 6);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.pickSpeed -= .3f;

        if (player.ZoneRockLayerHeight)
        {
            player.statDefense += 5;
            player.endurance += 0.03f;
        }

        Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .7f, .8f, .8f);
    }

    //Found in Svartalvheim chest
}