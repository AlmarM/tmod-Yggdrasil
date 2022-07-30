using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Runemaster.Content.Buffs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Consumables;

public class RunicPotion : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Mead");

        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        Tooltip.SetDefault($"20% increased {runicText} damage");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = 30;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 2);
        Item.buffType = ModContent.BuffType<RunicBuff>();
        Item.buffTime = TimeUtils.MinutesToTicks(4);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Shiverthorn)
        .AddIngredient(ItemID.IceBlock, 25)
        .AddTile(TileID.Bottles)
        .Register();
}