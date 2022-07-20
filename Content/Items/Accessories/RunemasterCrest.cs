using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunemasterCrest : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Runemaster Crest");
        Tooltip.SetDefault($"12% increased {runicText} damage" +
                           $"\n10% increased {runicText} critical strike chance" +
                           $"\n15% increase {runicText} attack speed");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 6);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.12f;
        player.GetCritChance<RunicDamageClass>() += 10;
        player.SetEffect<RunemasterCrest>();
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RunemasterEmblem>()
        .AddIngredient(ItemID.SoulofFright, 5)
        .AddIngredient(ItemID.SoulofMight, 5)
        .AddIngredient(ItemID.SoulofSight, 5)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}