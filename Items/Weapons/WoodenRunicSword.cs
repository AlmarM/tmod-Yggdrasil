using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

// YggdrasilItem is only used for location our images in the Assets/ folder
public class WoodenRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Wooden Runic Sword");
		Tooltip.SetDefault("[c/ae804f:Runic Power 1]" +
				"\nGrant +1 damage");
        // How many times we need to destroy this item before unlocking it for duplication in Journey mode
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
	
	int baseDamage = 7; //base weapon damage used by Item.Damage
    public override void SetDefaults()
    {
        // Please adjust as needed
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = baseDamage;
        Item.crit = 4;
        Item.knockBack = 4;
		Item.value = Item.buyPrice(copper: 20);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
	
    }

    public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 15)
		.AddTile(TileID.WorkBenches)
        .Register();
		
	public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 1)
        {
            Item.damage = baseDamage+1;
        }
        
	}
}