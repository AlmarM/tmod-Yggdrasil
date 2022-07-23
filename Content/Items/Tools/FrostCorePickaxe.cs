using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Tools;

public class FrostCorePickaxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Pickaxe");
        Tooltip.SetDefault("50% chance to inflict frostburn for 2 sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.autoReuse = true;
        Item.damage = 18;
        Item.crit = 0;
        Item.knockBack = 3;
        Item.pick = 55;
        Item.value = Item.sellPrice(0, 0, 23);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostCoreBar>(10)
        .AddIngredient<NordicWood>(5)
        .AddTile(TileID.Anvils)
        .Register();



    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {

        if (Main.rand.NextFloat() <= .5f)
        {
            target.AddBuff(BuffID.Frostburn, 120);
        }
    }
}