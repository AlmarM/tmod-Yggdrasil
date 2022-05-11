using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class GrassRunicBlade : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerThreeText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Runic Grass Blade");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: Has 50% chance to inflict poison based on {runicPowerText}" +
            $"\n{runicPowerThreeText} Grants +3 {runicText} damage 2% increased {runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 0;
        Item.knockBack = 5;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        int poisonTime = runePlayer.RunePower * 60;

        if (runePlayer.RunePower >= 1)
        {
            if (Main.rand.NextFloat() < 0.5f)
            {
                target.AddBuff(BuffID.Poisoned, poisonTime);
            }
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            damage.Flat += 3;
        }
    }

    public override void ModifyWeaponCrit(Player player, ref float crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            crit += 2;
        }
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.Stinger, 15)
        .AddIngredient(ItemID.RichMahogany, 10)
        .AddIngredient(ItemID.GoldBar, 6)
        .AddTile<DvergrForgeTile>()
        .Register();

        CreateRecipe()
        .AddIngredient(ItemID.Stinger, 15)
        .AddIngredient(ItemID.RichMahogany, 10)
        .AddIngredient(ItemID.PlatinumBar, 6)
        .AddTile<DvergrForgeTile>()
        .Register();
    }
}