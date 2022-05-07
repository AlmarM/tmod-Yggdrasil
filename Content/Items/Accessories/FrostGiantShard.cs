using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Accessories;

public class FrostGiantShard : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");

        DisplayName.SetDefault("Frost Giant Shard");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\nIncrease defense by 5 in snow biome"+
                           $"\nProvides life regeneration in snow biome");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 2);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.1f;

        if (player.ZoneSnow)
            player.statDefense += 5;
            player.lifeRegen += 5;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreBar>(30)
        .AddIngredient(ItemID.FrostCore)
        .AddTile(TileID.WorkBenches)
        .Register();
}