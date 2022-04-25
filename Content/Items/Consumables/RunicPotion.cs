using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Consumables;

public class RunicPotion : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
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
        Item.value = Item.buyPrice(0, 0, 2);
        Item.buffType = ModContent.BuffType<RunicBuff>();
        Item.buffTime = TimeUtils.MinutesToTicks(4);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Shiverthorn)
        .AddTile(TileID.Bottles)
        .Register();
}