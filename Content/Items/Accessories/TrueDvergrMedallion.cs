using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Svartalvheim.Content.Items.Accessories;

namespace Yggdrasil.Content.Items.Accessories;

[AutoloadEquip(EquipType.Neck)]
public class TrueDvergrMedallion : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("True Dvergr Medallion");
        Tooltip.SetDefault("50% increased mining speed" +
                           "\nGenerates Light" +
                           "\nIncreases defense by 10 when underground" +
                           "\nGrants 5% damage reduction when underground" +
                           "\nGrants immunity to fire blocks and lava");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Red;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 10);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.pickSpeed -= .5f;
        player.lavaImmune = true;
        player.fireWalk = true;

        if (player.ZoneRockLayerHeight)
        {
            player.statDefense += 10;
            player.endurance += 0.05f;
        }

        Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .7f, .8f, .8f);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.LunarBar)
        .AddIngredient<DwarvenMedallion>()
        .AddIngredient<SvartalvheimMedallion>()
        .AddIngredient<TrueHeroFragment>()
        .AddTile(TileID.LunarCraftingStation)
        .Register();
}