using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

public class NidhoggTooth : YggdrasilItem, IPlayerOnHitNPCWithProjModHook
{
    public int Priority { get; }

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Nidhogg's Tooth");
        Tooltip.SetDefault($"5% increased {runicText} critical strike chance" +
                           $"\nHitting an enemy with a {runicText} weapon slows the target by 25% and applies Venom 3 seconds");
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.LightRed;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<RunemasterPlayer>().SlowDebuffValue = .75f; //it means 25% slow
        player.GetCritChance<RunicDamageClass>() += 5;
        player.GetYggdrasilPlayer().AddModHooks(this);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.SpiderFang, 5)
        .AddIngredient(ItemID.PixieDust, 10)
        .AddIngredient(ItemID.VialofVenom)
        .AddTile<DvergrForgeTile>()
        .Register();

    public void OnPlayerHitNPCWithProj(Player player, Projectile proj, NPC target, int damage, float knockback,
        bool crit)
    {
        if (proj.ModProjectile is not RunicProjectile)
        {
            return;
        }

        target.AddBuff(ModContent.BuffType<SlowDebuff>(), TimeUtils.SecondsToTicks(3));
        target.AddBuff(BuffID.Venom, TimeUtils.SecondsToTicks(3));
    }
}