using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class ObsidianRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 4+");
        string runicPowerThreeText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 5");

        DisplayName.SetDefault("Runic Obsidian Sword");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: 50% chance to inflict fire damage for half {runicPowerText} sec" +
            $"\n{runicPowerTwoText}: Grants +5 {runicText} damage" +
            $"\n{runicPowerThreeText}: 10% increased {runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 35;
        Item.crit = 0;
        Item.knockBack = 6;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            target.AddBuff(BuffID.OnFire, TimeUtils.SecondsToTicks(runePlayer.RunePower / 2));
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 4)
        {
            flat += 5;
        }
    }

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower == 5)
        {
            crit += 10;
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dustType = 127;
        int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dustType);

        Dust dust = Main.dust[dustIndex];
        dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
        dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.HellstoneBar, 20)
        .AddIngredient(ItemID.Obsidian, 20)
        .AddTile(TileID.Anvils)
        .Register();
}