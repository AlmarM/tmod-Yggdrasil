using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class OccultHelmet : YggdrasilItem
{
    private string _runicText;
    private string _runicPowerText;

    public override void SetStaticDefaults()
    {
        _runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        _runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Occult Helmet");
        Tooltip.SetDefault($"5% increased {_runicText} damage" +
                           $"\n5% increased {_runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.defense = 6;
        Item.value = Item.sellPrice(0, 0, 60);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<OccultPlate>() &&
               legs.type == ModContent.ItemType<OccultBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = $"{_runicPowerText}: Apply Occult Buff ";

        var runePlayer = player.GetModPlayer<RunePlayer>();

        if (runePlayer.RunePower >= 3)
        {
            player.AddBuff(ModContent.BuffType<OccultBuff>(), 2);
            player.AddBuff(BuffID.Battle, 2);
        }
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>() += 0.05f;
        player.GetCritChance<RunicDamageClass>() += 5;
    }

    public override void AddRecipes() => CreateRecipe()
            .AddIngredient<OccultShard>(15)
            .AddIngredient(ItemID.Bone, 50)
            .AddTile<DvergrForgeTile>()
            .Register();

     
}