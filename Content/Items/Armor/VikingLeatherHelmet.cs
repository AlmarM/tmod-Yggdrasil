using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class VikingLeatherHelmet : YggdrasilItem
{
    private string _runicText;
    private string _runicPowerText;

    public override void SetStaticDefaults()
    {
        _runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        _runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");

        DisplayName.SetDefault("Viking Helmet");
        Tooltip.SetDefault($"2% increased {_runicText} damage");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.White;
        Item.defense = 3;
        Item.value = Item.sellPrice(0, 0, 5);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<VikingLeatherShirt>() &&
               legs.type == ModContent.ItemType<VikingLeatherBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = $"1% increased {_runicText} damage" +
                          $"\n1% increased {_runicText} critical strike chance" +
                          $"\nGrants +1 {_runicPowerText}";

        player.GetDamage<RunicDamageClass>() += 0.01f;
        player.GetCritChance<RunicDamageClass>() += 1;
        player.GetModPlayer<RunePlayer>().RunePower += 1;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>() += 0.02f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<Linnen>(5)
        .AddRecipeGroup(RecipeGroupID.IronBar, 5)
        .AddTile(TileID.Anvils)
        .Register();
}