using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class JarlHelmet : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jarl Helmet");
            Tooltip.SetDefault("4% increased [c/ae804f:runic] damage");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;
            Item.value = Item.sellPrice(0, 0, 30, 0);
        }
		
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<JarlShirt>() && legs.type == ModContent.ItemType<JarlBoots>();
		}
		
		public override void UpdateArmorSet(Player player) 
		{			
			player.setBonus = "4% increased [c/ae804f:runic] damage \nGrants +1[c/ae804f: Runic Power] \n[c/ae804f:Runic Power 3+]: Slowly regenerate life ";
			player.GetDamage<RunicDamageClass>() += 0.04f;
			player.GetModPlayer<YggdrasilPlayer>().RunePower += 1;

			var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
			if (modPlayer.RunePower >= 3)
			{
				player.lifeRegen += 5;
			}
	
		}
		
        public override void UpdateEquip(Player player)
        {
			player.GetDamage<RunicDamageClass>() += 0.04f;
        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(Mod, "Linnen", 10)
			.AddIngredient(ItemID.GoldBar, 10)
			.AddTile(TileID.Anvils)
			.Register();

			CreateRecipe()
			.AddIngredient(Mod, "Linnen", 10)
			.AddIngredient(ItemID.PlatinumBar, 10)
			.AddTile(TileID.Anvils)
			.Register();
		}
		
    }
}
