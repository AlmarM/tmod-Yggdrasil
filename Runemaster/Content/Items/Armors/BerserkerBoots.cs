using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Extensions;
using Yggdrasil.ModEffects;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Legs)]
public class BerserkerBoots : YggdrasilItem
{
    [CloneByReference] private readonly RunicAttackSpeedModEffect _runicAttackSpeedEffect = new(0.1f);

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Boots");
        Tooltip.SetDefault($"'{_runicAttackSpeedEffect.EffectDescription}" +
                           "\n10% increase movement speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.defense = 8;
        Item.value = Item.sellPrice(0, 0, 65);
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.1f;
        player.GetYggdrasilPlayer().AddModHooks(_runicAttackSpeedEffect);
    }
}