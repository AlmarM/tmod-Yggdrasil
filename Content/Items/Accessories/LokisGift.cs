using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    public class LokisGift : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

            DisplayName.SetDefault("Loki's Gift");
            Tooltip.SetDefault($"20% increased {runicText} damage when {insanityText} is over 30");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 6);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
            if (player.GetModPlayer<RunemasterPlayer>().Insanity > 30)
            {
                player.GetDamage<RunicDamageClass>() += 0.2f;
            }
        }

        //Dropped by Hallowed Mimic
    }
}