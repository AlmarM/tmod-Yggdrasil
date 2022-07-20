using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class FrostGiantBelt : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Frost Giant Belt");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\n5% increased { runicText} critical strike chance" +
                           $"\nIncrease defense by 5 in snow biome" +
                           $"\nProvides life regeneration in snow biome" +
                           $"\nGrants immunity to fire blocks" +
                           $"\nCritical hit caused by {runicText} weapons releases many frost sparks");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.1f;

        if (player.ZoneSnow)
        {
            player.statDefense += 5;
            player.lifeRegen += 5;
        }

        player.GetCritChance<RunicDamageClass>() += 5;
        player.SetEffect<FrostGiantHand>();
        player.fireWalk = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostGiantHand>()
        .AddIngredient<FrostGiantShard>()
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
}