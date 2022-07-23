using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class SurtrBelt : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Surtr Belt");
        Tooltip.SetDefault($"15% increased {runicText} damage" +
                           "\nIncreases max life by 20" +
                           "\nGrants immunity to OnFire, Shadowflame, Frostburn, Chilled and Frozen" +
                           "\nGrants immunity to fire blocks and lava" +
                           $"\nIgnites nearby enemies");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.accessory = true;
        Item.rare = ItemRarityID.Yellow;
        Item.buffType = BuffID.Inferno;
        Item.value = Item.sellPrice(0, 7);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.15f;
        player.AddBuff(BuffID.Inferno, 2);

        player.lavaImmune = true;
        player.fireWalk = true;
        player.statLifeMax2 += 20;
        player.buffImmune[BuffID.Burning] = true;
        player.buffImmune[BuffID.OnFire] = true;
        player.buffImmune[BuffID.Chilled] = true;
        player.buffImmune[BuffID.Frozen] = true;
        player.buffImmune[BuffID.ShadowFlame] = true;
        player.buffImmune[BuffID.Frostburn] = true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.InfernoPotion)
        .AddIngredient(ItemID.LifeforcePotion)
        .AddIngredient(ItemID.HellstoneBar, 5)
        .AddIngredient<SunPebble>()
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}