using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class SilverRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("Runic Silver Sword");
        Tooltip.SetDefault($"{runicPowerOneText}: Grants +1 {runicText} damage" +
                           $"\n{runicPowerTwoText}: Enables auto swing");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 24;
        Item.useAnimation = 24;
        Item.autoReuse = false;
        Item.damage = 10;
        Item.crit = 0;
        Item.knockBack = 5;
        Item.value = Item.buyPrice(0, 0, 9);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.SilverBar, 8)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.TungstenBar, 8)
            .AddTile(TileID.Anvils)
            .Register();
    }


    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 1)
        {
            flat += 1;
        }
    }

    public override void HoldItem(Player player)
    {
        Item.autoReuse = false;

        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            Item.autoReuse = true;
        }
    }
}