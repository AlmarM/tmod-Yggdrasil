using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Runic;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class ObsidianRunicHammer : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Obsidian Warhammer");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 30;
        Item.crit = 0;
        Item.knockBack = 10;
        Item.value = Item.buyPrice(0, 0, 55);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        base.OnHitNPC(player, target, damage, knockback, crit);

        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 4)
        {
            const float projectileSpeed = 6f;
            const float radius = 25f;

            int projectileCount = (int)MathF.Min(runePlayer.RunePower, 6);
            int projectileType = ModContent.ProjectileType<FireProjectile>();
            float delta = MathF.PI * 2 / projectileCount;

            for (var i = 0; i < projectileCount; i++)
            {
                float theta = delta * i;
                var position = target.Center + Vector2.One.RotatedBy(theta) * radius;

                Vector2 direction = position - target.Center;
                direction = Vector2.Normalize(direction);
                direction = Vector2.Multiply(direction, projectileSpeed);

                Projectile.NewProjectile(null, position, direction, projectileType, 20, 2, player.whoAmI);
            }
        }
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        var runePower = string.Format(RuneConfig.RunePowerLabel, 4);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Spawn fireballs on hit";

        return tooltip;
    }

    protected override void AddEffects()
    {
        //@todo the OnFire doesn't apply even tho' it's the same code as the Obisidian Runic Sword
        AddEffect(new BiggerSizeEffect(2, 0.5f));
        AddEffect(new InflictBuffEffect(2, BuffID.OnFire, 3, "OnFire", 1f, true));
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