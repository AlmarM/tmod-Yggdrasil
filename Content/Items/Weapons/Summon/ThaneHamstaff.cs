using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles.Summon;

namespace Yggdrasil.Content.Items.Weapons.Summon;

public class ThaneHamstaff : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Thane Hamstaff");
        Tooltip.SetDefault("Summons a dwarf spirit to fight for you");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 80;
        Item.knockBack = 0f;
        Item.mana = 10;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(gold: 10);
        Item.rare = ItemRarityID.Yellow;
        Item.UseSound = SoundID.Item44;

        // this item doesn't do any melee damage
        Item.noMelee = true;

        // Makes the damage register as summon. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type
        Item.DamageType = DamageClass.Summon;

        // No buffTime because otherwise the item tooltip would say something like "1 minute duration"
        Item.buffType = ModContent.BuffType<DwarfSpiritSummonBuff>();

        Item.shoot = ModContent.ProjectileType<DwarfSpiritSummonProjectile>();
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
        ref int damage, ref float knockback)
    {
        // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
        position = Main.MouseWorld;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
        player.AddBuff(Item.buffType, 2);

        // Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
        var projectile =
            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
        projectile.originalDamage = Item.damage;

        // Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
        return false;
    }
}