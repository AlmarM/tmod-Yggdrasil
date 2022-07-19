using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Runemaster;

namespace Yggdrasil.Content.Items.Armor;

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
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        player.setBonus = $"Increases {insanityText} removed by {focusText} power by 1\nApplies Berserker Rage buff";

        float HealthThreshold = .25f;
        
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (player.statLife < HealthThreshold * player.statLifeMax2)
        {
            player.AddBuff(ModContent.BuffType<BerserkerRageBuff>(), 2);
        }

        player.GetModPlayer<RunePlayer>().InsanityRemoverValue += 1;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 3;
    }

}