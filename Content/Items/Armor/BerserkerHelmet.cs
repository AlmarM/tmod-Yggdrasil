using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class BerserkerHelmet : YggdrasilItem
{
    private string _runicText;
    private string _runicPowerText;
    //private string _runicPowerThreeText;

    public override void SetStaticDefaults()
    {
        _runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        _runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Berserker Wolf Skin");
        Tooltip.SetDefault($"5% increased {_runicText} damage" +
                           $"\n5% increased {_runicText} critical strike chance");

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
        player.setBonus = $"While below 25% health, 20% increase {_runicText} damage and critical strike chance";

        float HealthThreshold = .25f;
        
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (player.statLife < HealthThreshold * player.statLifeMax2)
        {
            player.GetDamage<RunicDamageClass>() += 0.2f;
            player.GetCritChance<RunicDamageClass>() += 20;
        }
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>() += 0.05f;
        player.GetCritChance<RunicDamageClass>() += 5;
    }

}