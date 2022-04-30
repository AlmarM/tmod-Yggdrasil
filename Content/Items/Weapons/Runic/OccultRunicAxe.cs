using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class OccultRunicAxe : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Occult Axe");

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
        Item.value = Item.sellPrice(0, 0, 50);
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
        Item.shoot = ModContent.ProjectileType<OccultAxeProjectile>();
        Item.shootSpeed = 12f;
    }

    public override bool AltFunctionUse(Player player)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        return runePlayer.RunePower >= 3;
    }

    public override bool? UseItem(Player player)
    {
        Item.noUseGraphic = player.altFunctionUse == 2;

        return base.UseItem(player);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type,
        int damage, float knockback)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        return runePlayer.RunePower >= 3 && player.altFunctionUse == 2;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>(10)
        .AddTile(TileID.Anvils)
        .Register();

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        var runePower = string.Format(RuneConfig.RunePowerLabel, 4);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Spawn an axe clone on critical strike";

        return tooltip;
    }

    protected override void AddEffects()
    {
        AddEffect(new AttackSpeedEffect(2, 0.25f));
    }
}