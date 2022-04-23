using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Weapons;

public class OccultRunicSword : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Occult Runic Sword");
        Tooltip.SetDefault("[c/ae804f:Runic Power 1+]: Enables auto swing & increase attack speed" +
							"\n[c/ae804f:Runic Power 3+]: Grants +2 [c/ae804f:runic] damage & 5% increased [c/ae804f:runic] critical strike chance");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 25;
        Item.crit = 0;
        Item.knockBack = 5;
		Item.value = Item.buyPrice(0, 1, 75, 0);
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "OccultShard", 10)
        .AddTile(TileID.Anvils)
        .Register();


	public override void HoldItem(Player player)
	{
		Item.autoReuse = false;

		var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
		if (modPlayer.RunePower >= 1)
		{
			Item.autoReuse = true;
		}
	}

    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 3)
        {
            crit += 5;
        }

    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 3)
        {
            flat += 2;
        }
    }

    public override float UseSpeedMultiplier(Player player)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 1)
        {
            return 1.25f;
        }
        return 1f;
    }

}