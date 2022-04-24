using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Projectiles;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;
public class DemoniteRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Demonite Runic Axe");
        Tooltip.SetDefault("[c/ae804f:Runic Power 2+]: 5% increased [c/ae804f:runic] critical strike chance" +
            "\n[c/ae804f:Runic Power 4+] Spawn an axe clone on critical strike");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 23;
        Item.crit = 6;
        Item.knockBack = 6;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 27, 0);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.DemoniteBar, 12)
        .AddTile(TileID.Anvils)
        .Register();

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 2)
        {
            crit += 5;
        }

    }
    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 4)
        {
            if (crit)
            {
                Vector2 npcLocation = target.Center;
                var radius = 200f;
                var theta = Main.rand.NextFloat(0, MathF.PI * 2f);
                var x = npcLocation.X + MathF.Cos(theta) * radius;
                var y = npcLocation.Y + MathF.Sin(theta) * radius;

                var spawnPosition = new Vector2(x, y);
                var direction = target.Center - spawnPosition;
                direction.Normalize();

                var speed = 6f;
                var speedX = direction.X * speed;
                var speedY = direction.Y * speed;

                Projectile.NewProjectile(null, x, y, speedX, speedY, ModContent.ProjectileType<DemoniteRunicAxeProjectile>(), 23, 0, player.whoAmI);
            }

        }
    }
}