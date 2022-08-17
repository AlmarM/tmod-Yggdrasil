using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

public class HelsNail : YggdrasilItem, IPlayerOnHitNPCWithProjModHook
{
    public int Priority { get; }

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Hel's Nail");
        Tooltip.SetDefault($"All {runicText} weapons now inflict poison for 5 sec");
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetYggdrasilPlayer().AddModHooks(this);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BloodDrops>(10)
        .AddIngredient(ItemID.Stinger, 5)
        .AddTile<DvergrForgeTile>()
        .Register();

    public void PlayerOnHitNPCWithProj(Player player, Projectile proj, NPC target, int damage, float knockback,
        bool crit)
    {
        if (proj.ModProjectile is not RuneTabletProjectile)
        {
            return;
        }

        target.AddBuff(BuffID.Poisoned, TimeUtils.SecondsToTicks(5));
    }
}