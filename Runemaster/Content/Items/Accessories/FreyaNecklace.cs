using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Runemaster.Content.Projectiles.Tablets;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Accessories;

[AutoloadEquip(EquipType.Neck)]
public class FreyaNecklace : YggdrasilItem, IPlayerOnHitNPCWithProjModHook
{
    public int Priority { get; }

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Freya's Necklace");
        Tooltip.SetDefault($"Hitting an enemy with a {runicText} weapon has a chance to generate a heart");
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
        .AddIngredient(ItemID.Prismite)
        .AddIngredient<BloodDrops>(5)
        .AddTile<DvergrForgeTile>()
        .Register();

    public void PlayerOnHitNPCWithProj(Player player, Projectile proj, NPC target, int damage, float knockback,
        bool crit)
    {
        if (proj.ModProjectile is not RuneTabletProjectile || target.type == NPCID.TargetDummy)
        {
            return;
        }

        if (Main.rand.NextBool(100))
        {
            Item.NewItem(target.GetSource_DropAsItem(), target.Center, target.width, target.height, ItemID.Heart);
        }
    }
}