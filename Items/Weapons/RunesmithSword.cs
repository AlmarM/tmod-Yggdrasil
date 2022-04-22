using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class RunesmithSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runesmith Sword");
		Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Grants +1 [c/ae804f:runic] damage & increase attack speed");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
	
	
    public override void SetDefaults()
    {

        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 24;
        Item.useAnimation = 24;
        Item.autoReuse = false;
        Item.damage = 9;
        Item.crit = 0;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(0, 0, 5, 40);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 15)
		.AddRecipeGroup(RecipeGroupID.IronBar, 10)
		.AddTile(TileID.Anvils)
        .Register();
	
	
	public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 1)
        {
            flat += 1;
        }
        
	}
	
	public override float UseSpeedMultiplier(Player player)
	{
		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 1)
        {
            return 1.5f;
        }
		return 1f;	
	}

}