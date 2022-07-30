using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Players;
using Yggdrasil.Runemaster.Content.Buffs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Head)]
public class BerserkerHelmet : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Berserker Wolf Skin");
        Tooltip.SetDefault($"Increases {runicText} damage by 3");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.defense = 8;
        Item.value = Item.sellPrice(0, 0, 65);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<BerserkerChest>() &&
               legs.type == ModContent.ItemType<BerserkerBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        player.setBonus = $"Increases {insanityText} removed by {focusText} power by 1" +
                          "\nApplies Berserker Rage buff";

        if (player.statLife < 0.25f * player.statLifeMax2)
        {
            player.AddBuff(ModContent.BuffType<BerserkerRageBuff>(), 2);
        }

        player.GetModPlayer<RunemasterPlayer>().InsanityRemoverValue += 1;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 3;
    }
}