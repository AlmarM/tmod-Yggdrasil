using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class NorsemanShield : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
            string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

            DisplayName.SetDefault("Norsemen Shield");
            Tooltip.SetDefault("Grants immunity to knockback" +
                               "\nIncreases defense by 3" +
                               $"\n2% increased {runicText} damage" +
                               $"\nIncreases {insanityText} removed by {focusText} power by 1");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 2);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.statDefense += 3;
            player.GetDamage<RunicDamageClass>() += 0.02f;
            player.GetModPlayer<RunePlayer>().InsanityRemoverValue += 1;
        }
    }

}