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
    public class ValkyrieGoldenShield : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Valkyrie Golden Shield");
            Tooltip.SetDefault("Grants immunity to knockback" +
                               "\nIncreases defense by 7" +
                               "\nRegenerates life" +
                               "\nIncreases max life by 10");

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
            player.noKnockback = true;
            player.statDefense += 7;
            player.lifeRegen += 5;
            player.statLifeMax2 += 10;
        }
    }

}