using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class BerserkerHelmet : YggdrasilItem
{
    
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Berserker Wolf Skin");
        Tooltip.SetDefault($"5% increased {runicText} damage" +
                           $"\n5% increased {runicText} critical strike chance" +
                           "\nIncreases defense by 5");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.defense = 6;
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
        player.setBonus = $"While below 25% health, 20% increase {runicText} damage and critical strike chance";

        float HealthThreshold = .25f;
        
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (player.statLife < HealthThreshold * player.statLifeMax2)
        {
            player.GetDamage<RunicDamageClass>() += 0.2f;
            player.GetCritChance<RunicDamageClass>() += 20;
            player.statDefense += 5;
        }
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>() += 0.05f;
        player.GetCritChance<RunicDamageClass>() += 5;
    }

}