using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Consumables;

public class MeadBasic : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Honey Mead");

        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        Tooltip.SetDefault($"Increases {insanityText} gauge by 5");

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
        Item.value = Item.sellPrice(0, 0, 0, 10);
        Item.buffType = ModContent.BuffType<HoneyMeadBuff>();
        Item.buffTime = TimeUtils.MinutesToTicks(4);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.BottledHoney)
        .AddTile(TileID.Bottles)
        .Register();
}