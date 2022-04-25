using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class NorsemanShield : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Norsemen Shield");
        Tooltip.SetDefault("Grants immunity to knockback" +
                           "\nGrant + 3 defense" +
                           $"\nIncrease {runicText} damage by 1");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 2);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.noKnockback = true;
        player.statDefense += 3;
        //player.GetDamage<RunicDamageClass>() += 1;
    }
}