using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Ores;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Nordic.Content.Items.Tools;

public class NordicHamAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nordic HamAxe");
        Tooltip.SetDefault("Inflict frostburn for 2 sec");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = true;
        Item.damage = 70;
        Item.crit = 0;
        Item.knockBack = 8;
        Item.hammer = 100;
        Item.axe = 30; // multiplied by 5
        Item.value = Item.sellPrice(gold: 4);
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