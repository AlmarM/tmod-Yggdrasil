using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
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

    protected abstract int ProjectileCount { get; }

    protected abstract float AttackConeSize { get; }

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

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();

        CreateConeAttack(source, player, runemasterPlayer.RunicProjectileSpeedMultiplier, type, damage, knockback);

        return false;
    }

    protected virtual void OnFocusActivated(Player player)
    {
    }

    protected override IList<TooltipBlock> CreateTooltipBlocks()
    {
        var titleBlock = new TooltipBlock(TabletTooltipName.ClassTitle);
        titleBlock.AddLine(RuneConfig.ColoredRunemasterTitleLabel);
        titleBlock.SetInsertIndexFunc(tooltips =>
        {
            int lineIndex = tooltips.FindIndex(x => x.Name == "ItemName" && x.Mod == "Terraria");
            return lineIndex >= 0
                ? lineIndex + 1
                : null;
        });

        var focusBlock = new TooltipBlock(TabletTooltipName.Focus);

        ModifyFocusTooltipBlock(focusBlock);

        var blocks = new List<TooltipBlock>
        {
            titleBlock
        };

        if (focusBlock.LineCount > 0)
        {
            blocks.Add(focusBlock);
        }

        return blocks;
    }

    protected virtual void ModifyFocusTooltipBlock(TooltipBlock block)
    {
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

    protected virtual void CreateConeAttack(IEntitySource source, Player player, float speed, int type, int damage,
        float knockback)
    {
        float coneSize = MathHelper.Pi / AttackConeSize;
        float coneOffset = MathHelper.Pi / (AttackConeSize * 2f);

        RunemasterPlayer runemasterPlayer = player.GetRunemasterPlayer();
        runemasterPlayer.Insanity++;

        for (var i = 0; i < ProjectileCount; i++)
        {
            Vector2 direction = Main.MouseWorld - player.Center;
            direction.Normalize();

            Vector2 velocity = Main.rand.NextVector2Unit(direction.ToRotation() - coneOffset, coneSize);
            velocity *= speed;

            int index = Projectile.NewProjectile(source, player.Center, velocity, type, damage, knockback,
                player.whoAmI);

            OnConeProjectileCreated(source, player.Center, velocity, type, damage, knockback, player.whoAmI, index);
        }
    }

    protected virtual void OnConeProjectileCreated(IEntitySource source, Vector2 position, Vector2 velocity, int type,
        int damage, float knockback, int owner, int index)
    {
    }
}