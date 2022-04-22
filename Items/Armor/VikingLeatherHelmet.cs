using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class VikingLeatherHelmet : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Helmet");
            Tooltip.SetDefault("2% increased [c/ae804f:runic] damage");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.rare = ItemRarityID.White;
            Item.defense = 3;
            Item.value = Item.sellPrice(0, 0, 5, 0);
        }
		
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<VikingLeatherShirt>() && legs.type == ModContent.ItemType<VikingLeatherBoots>();
		}
		
		public override void UpdateArmorSet(Player player) 
		{			
			player.setBonus = "1% increased [c/ae804f:runic] damage \n1% increased [c/ae804f:runic] critical strike chance \nGrants +1[c/ae804f: Runic Power]";
			player.GetDamage<RunicDamageClass>() += 0.01f;
			player.GetCritChance<RunicDamageClass>() += 1;	
			player.GetModPlayer<YggdrasilPlayer>().RunePower += 1;			
		}
		
        public override void UpdateEquip(Player player)
        {
			player.GetDamage<RunicDamageClass>() += 0.02f;
        }

        public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "Linnen", 5)
		.AddRecipeGroup(RecipeGroupID.IronBar, 5)
		.AddTile(TileID.Anvils)
        .Register();
		
    }
}
