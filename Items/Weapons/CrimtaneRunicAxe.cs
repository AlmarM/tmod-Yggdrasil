using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;


namespace Yggdrasil.Items.Weapons;
public class CrimtaneRunicAxe : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crimtane Runic Axe");
        Tooltip.SetDefault("[c/ae804f:Runic Power 2+]: 5% increased [c/ae804f:runic] critical strike chance" +
            "\n[c/ae804f:Runic Power 4+] Heal for half [c/ae804f:Runic Power] on critical strike to a maximum of 5");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.autoReuse = false;
        Item.damage = 28;
        Item.crit = 7;
        Item.knockBack = 6;
        Item.axe = 13;
        Item.value = Item.buyPrice(0, 0, 27, 0);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.CrimtaneBar, 12)
        .AddTile(TileID.Anvils)
        .Register();
    public override void ModifyWeaponCrit(Player player, ref int crit)
    {
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        if (modPlayer.RunePower >= 2)
        {
            crit += 5;
        }

    }
    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {        
        var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
        int healingRunePower = (modPlayer.RunePower / 2);
        if (healingRunePower >= 5)
        {
            healingRunePower = 5;
        }
        if (modPlayer.RunePower >= 4)
        {
            if (crit)
            {
                player.statLife += healingRunePower;
                player.HealEffect(healingRunePower);
            }
        }
    }

}