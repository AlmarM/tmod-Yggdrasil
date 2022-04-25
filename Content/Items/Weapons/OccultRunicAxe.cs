using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class OccultRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");
        string runicPowerThreeText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 3+");

        DisplayName.SetDefault("Occult Runic Axe");
        Tooltip.SetDefault($"{runicPowerTwoText}: Increase attack speed" +
                           $"\n{runicPowerThreeText}: Can be thrown");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.damage = 25;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.axe = 14;
        Item.knockBack = 5;
        Item.crit = 6;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 1);
        Item.rare = ItemRarityID.Green;
        //Item.shoot = ModContent.ProjectileType<OccultAxeProjectile>();
        //Item.shootSpeed = 12f;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
    }

    public override bool AltFunctionUse(Player player)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        return runePlayer.RunePower >= 3;
    }

    public override bool CanUseItem(Player player)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            if (player.altFunctionUse == 2)
            {
                Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
                Item.useTime = 28;
                Item.useAnimation = 28;
                Item.noMelee = true;
                Item.noUseGraphic = true;
                Item.shoot = ModContent.ProjectileType<OccultAxeProjectile>();
                Item.shootSpeed = 15f;
            }
            else
            {
                Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
                Item.noUseGraphic = false;
                Item.useTime = 28;
                Item.useAnimation = 28;
                Item.noMelee = false;
                Item.shoot = ProjectileID.None;
            }
        }

        return true;
    }

    public override float UseSpeedMultiplier(Player player)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        return runePlayer.RunePower >= 2 ? 1.25f : 1f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>(10)
        .AddTile(TileID.Anvils)
        .Register();
}