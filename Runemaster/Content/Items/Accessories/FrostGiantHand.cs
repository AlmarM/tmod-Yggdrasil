using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.ModEffects;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
public class FrostGiantHand : YggdrasilItem
{
    private BlizzardExplosionModEffect _blizzardExplosionEffect;

    public override void SetStaticDefaults()
    {
        _blizzardExplosionEffect = new BlizzardExplosionModEffect(Item);

        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Frost Giant Hand");
        Tooltip.SetDefault($"5% increased {runicText} critical strike chance" +
                           "\nGrants immunity to fire blocks" +
                           $"{_blizzardExplosionEffect.EffectDescription}");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 2);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetCritChance<RunicDamageClass>() += 5;
        player.fireWalk = true;
        player.GetYggdrasilPlayer().AddModHooks(_blizzardExplosionEffect);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.FrostDaggerfish)
        .AddIngredient<FrostcoreBar>(10)
        .AddTile<DvergrForgeTile>()
        .Register();
}