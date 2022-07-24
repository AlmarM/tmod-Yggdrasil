using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Head)]
public class JomsborgCasque : YggdrasilItem, IPlayerUseSpeedMultiplierModHook
{
    public int Priority { get; }

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Jomsborg Casque");
        Tooltip.SetDefault($"Increases {runicText} damage by 9");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;
        Item.defense = 15;
        Item.value = Item.sellPrice(0, 4, 80);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<JomsborgScale>() &&
               legs.type == ModContent.ItemType<JomsborgBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        var runemasterPlayer = player.GetModPlayer<RunemasterPlayer>();
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");
        string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        player.setBonus = $"Increases {insanityText} removed by {focusText} power by 2" +
                          $"\nIncreases {insanityText} gauge by 10" +
                          "\nGrants immunity to knockback" +
                          $"\nThe more {insanityText}, the more {runicText} attack speed";

        player.noKnockback = true;
        player.SetEffect<JomsborgCasque>();

        runemasterPlayer.InsanityThreshold += 10;
        runemasterPlayer.InsanityRemoverValue += 2;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 9;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SturdyLeaf>(10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();


    public void PlayerUseSpeedMultiplier(Player player, Item item, ref float currentMultiplier)
    {
        if (item.ModItem is not RuneTablet)
        {
            return;
        }

        var runemasterPlayer = player.GetModPlayer<RunemasterPlayer>();
        currentMultiplier += runemasterPlayer.Insanity / 100f;
    }
}