using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Items.Tools;

public class VikingDaneAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Dane Axe");
        Tooltip.SetDefault("That's a long one");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 30;
        Item.DamageType = DamageClass.Melee;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.axe = 12;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.crit = 6;
        Item.value = Item.sellPrice(silver: 80);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }
}