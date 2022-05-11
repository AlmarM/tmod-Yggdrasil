using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class SpikyRunicSword : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Spiky Runic Sword");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = true;
        Item.damage = 25;
        Item.crit = 0;
        Item.knockBack = 3;
        Item.value = Item.buyPrice(0, 0, 50);
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SpikyBall, 50)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new AttackSpeedEffect(2, 0.25f));
    }

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 3);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Has 50% on hit to throw a spiky ball";

        return tooltip;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 3)
        {
            if (Main.rand.NextFloat() < .5f)
            {
                // @todo clean up in the future
                var x = player.Center.X;
                var y = player.Center.Y;

                var direction = target.Center - player.Center;
                direction.Normalize();

                var speed = 6f;
                float speedX = direction.X * speed;
                float speedY = direction.Y * speed;
                int projectileType = ProjectileID.SpikyBall;
                int projectileDamage = (Item.damage / 2);

                Projectile.NewProjectile(null, x, y, speedX, speedY, projectileType, projectileDamage, 0,
                    player.whoAmI);
            }
        }
    }
}