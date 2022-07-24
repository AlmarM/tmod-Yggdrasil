using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModHooks.Player;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Items.Armors;

[AutoloadEquip(EquipType.Head)]
public class OccultHelmet : YggdrasilItem, IPlayerOnHitNPCWithProjModHook
{
    public int Priority { get; }

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Occult Helmet");
        Tooltip.SetDefault($"Increases {runicText} damage by 1" +
                           $"\n2% increased {runicText} critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Orange;
        Item.defense = 6;
        Item.value = Item.sellPrice(0, 0, 60);
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<OccultPlate>() &&
               legs.type == ModContent.ItemType<OccultBoots>();
    }

    public override void UpdateArmorSet(Player player)
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
        string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

        //all the spaces there is a workaround because the text doesnt fit on screen
        player.setBonus = $"Increases {insanityText} gauge by 3" +
                          $"\nCritical hit caused by {runicText} weapons will confuse target" +
                          "\nApply Occult Buff";

        player.AddBuff(ModContent.BuffType<OccultBuff>(), 2);
        player.GetModPlayer<RunemasterPlayer>().InsanityThreshold += 3;
        player.GetYggdrasilPlayer().AddModHooks(this);
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage<RunicDamageClass>().Flat += 1;
        player.GetCritChance<RunicDamageClass>() += 2;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OccultShard>(15)
        .AddIngredient(ItemID.Bone, 50)
        .AddTile<DvergrForgeTile>()
        .Register();


    public void OnPlayerHitNPCWithProj(Player player, Projectile proj, NPC target, int damage, float knockback,
        bool crit)
    {
        if (!crit || proj.ModProjectile is not RunicProjectile)
        {
            return;
        }

        target.AddBuff(BuffID.Confused, TimeUtils.SecondsToTicks(3));
    }
}