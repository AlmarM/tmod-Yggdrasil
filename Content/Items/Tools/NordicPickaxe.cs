using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Tools;

public class NordicPickaxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nordic Pickaxe");
        Tooltip.SetDefault("Inflict frostburn for 2 sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 14;
        Item.useAnimation = 14;
        Item.autoReuse = true;
        Item.damage = 65;
        Item.crit = 0;
        Item.knockBack = 5;
        Item.pick = 215;
        Item.value = Item.sellPrice(0, 4);
        Item.rare = ItemRarityID.Yellow;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Frostburn, 120);  
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<ColdIronBar>(5)
        .AddIngredient<NordicWood>(10)
        .AddTile(TileID.MythrilAnvil)
        .Register();
   
}