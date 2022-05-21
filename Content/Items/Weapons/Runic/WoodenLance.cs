using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class WoodLance : RunicItem
{
    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Wooden Lance");

        // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
        ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 18;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 4;
        Item.crit = 0;
        Item.noUseGraphic = true;
        Item.DamageType = DamageClass.Melee;
        Item.noMelee = true;
        Item.shootSpeed = 3.5f;
        Item.shoot = ModContent.ProjectileType<WoodLanceProjectile>();

        Item.value = Item.sellPrice(0, 0, 18, 0);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
    }

    public override bool? UseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            player.AddBuff(ModContent.BuffType<DefensiveStanceBuff>(), TimeUtils.SecondsToTicks(5));

            return false;
        }

        return base.UseItem(player);
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (player.HasBuff<DefensiveStanceBuff>())
        {
            // 20% increase?
            damage += 0.2f;
        }
    }

    public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 10)
        .AddTile(TileID.WorkBenches)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(1, 2));
    }
}