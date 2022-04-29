using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons;

public class MeteorineRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string runicPowerOneText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 1+");
        string runicPowerTwoText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "Runic Power 2+");

        DisplayName.SetDefault("Runic Meteorite Axe");
        Tooltip.SetDefault(
            $"{runicPowerOneText}: Grants +1 {runicText} damage & has 25% chance to inflict fire damage for 1 sec" +
            $"\n{runicPowerTwoText}: Grants +2 {runicText} damage & adds 25% chance to inflict fire damage for 2 more sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.autoReuse = false;
        Item.damage = 17;
        Item.crit = 7;
        Item.knockBack = 7;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 27);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        if (runePlayer.RunePower >= 2)
        {
            flat += 2;
        }

        if (runePlayer.RunePower >= 1)
        {
            flat += 1;
        }
    }

    int baseOnFire = 60; //base Onfire time for the debuff 60 = 1sec
    float baseOnFireChance = 0f;

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        float onFireProcChance = baseOnFireChance;

        if (runePlayer.RunePower >= 1)
        {
            onFireProcChance += .25f;
            if (Main.rand.NextFloat() < onFireProcChance)
            {
                target.AddBuff(BuffID.OnFire, baseOnFire);
            }
        }

        int onFireDuration = baseOnFire;

        if (runePlayer.RunePower >= 2)
        {
            onFireProcChance += .25f;
            onFireDuration *= 3;

            if (Main.rand.NextFloat() < onFireProcChance)
            {
                target.AddBuff(BuffID.OnFire, onFireDuration);
            }
        }

        Main.NewText(onFireProcChance);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.MeteoriteBar, 12)
        .AddTile(TileID.Anvils)
        .Register();
}