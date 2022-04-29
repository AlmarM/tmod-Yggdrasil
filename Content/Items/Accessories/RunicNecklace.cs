using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories;

public class RunicNecklace : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPower = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 5+");

        DisplayName.SetDefault("Runic Necklace");
        Tooltip.SetDefault($"10% increased {runicText} damage" +
                           $"\n5% increased {runicText} critical strike chance" +
                           $"\nGrants +2 {runicPowerText}" +
                           $"\n{runicPower} Generate Light");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Green;
        Item.accessory = true;
        Item.value = Item.buyPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage<RunicDamageClass>() += 0.1f;
        player.GetCritChance<RunicDamageClass>() += 3;
        player.GetModPlayer<RunePlayer>().RunePower += 1;

        var modPlayer = player.GetModPlayer<RunePlayer>();
        if (modPlayer.RunePower >= 5)
        {
            Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, .5f, .8f, .8f);
        }
    }

    public override void AddRecipes() => CreateRecipe()
            .AddIngredient<BerserkerRing>()
            .AddIngredient(ItemID.Bell)
            .AddTile(TileID.Anvils)
            .Register();
    
}