using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.Runemaster.Content.Items;

public abstract class RuneTablet : YggdrasilItem
{
    protected abstract int ProjectileId { get; }

    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.autoReuse = true;
        Item.UseSound = SoundID.Item20;
        Item.shootSpeed = 10f;
        Item.shoot = ProjectileId;
    }

    public override int ChoosePrefix(UnifiedRandom rand)
    {
        int[] allowedPrefixes = RuneConfig.AllowedRunicVanillaPrefixes;
        int prefixIndex = rand.Next(allowedPrefixes.Length);

        return allowedPrefixes[prefixIndex];
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        // Class title additions
        int lineIndex = tooltips.FindIndex(x => x.Name == "ItemName" && x.Mod == "Terraria");
        if (lineIndex >= 0)
        {
            string title = RuneConfig.ColoredRunemasterTitleLabel;
            tooltips.Insert(lineIndex + 1, new TooltipLine(Mod, "ClassTitle", title));
        }

        List<string> runicDescriptions = GetRunicEffectDescriptions();
        for (var i = 0; i < runicDescriptions.Count; i++)
        {
            string description = runicDescriptions[i];
            tooltips.Add(new TooltipLine(Mod, $"RunicEffectDescription_{i}", description));
        }
    }

    public override bool AltFunctionUse(Player player)
    {
        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();

        if (runemasterPlayer.Focus >= runemasterPlayer.FocusThreshold)
        {
            return true;
        }

        return false;
    }

    public override bool? UseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            OnFocusActivated(player);
            RemoveInsanity(player);

            return true;
        }

        return base.UseItem(player);
    }

    protected virtual void OnFocusActivated(Player player)
    {
    }

    protected virtual List<string> GetRunicEffectDescriptions()
    {
        return new List<string>();
    }

    private static void RemoveInsanity(Player player)
    {
        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();

        runemasterPlayer.Focus = 0;
        runemasterPlayer.Insanity -= runemasterPlayer.InsanityRemoverValue;
        runemasterPlayer.Insanity = (int)MathF.Max(runemasterPlayer.Insanity, 0);
    }

    protected static int[] CreateCircleExplosion(int projectileCount, Item item, Player player, int projectileId,
        float speed = 10)
    {
        var indexes = new int[projectileCount];

        for (var i = 0; i < projectileCount; i++)
        {
            var direction = Main.rand.NextVector2Unit();
            var velocity = direction * speed;
            int damage = item.damage;
            float knockback = item.knockBack;

            IEntitySource entitySource = player.GetSource_ItemUse(item);
            var index = Projectile.NewProjectile(entitySource, player.Center, velocity, projectileId, damage, knockback,
                player.whoAmI);

            indexes[i] = index;
        }

        return indexes;
    }

    protected static void HealByInsanity(Player player, float multiplier = 1f)
    {
        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        int insanity = runemasterPlayer.Insanity;

        if (player.statLife < player.statLifeMax2)
        {
            player.statLife += (int)(insanity * multiplier);
            player.HealEffect(insanity);
        }
    }
}