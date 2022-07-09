using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class VanirShield : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Vanir Shield");
            Tooltip.SetDefault("Grants immunity to knockback" +
                               "\nIncreases defense by 8" +
                               "\nRegenerates life" +
                               "\nIncreases max life by 10" +
                               "\nGrants immunity to most debuffs and fire blocks");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 7);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.statDefense += 8;
            player.lifeRegen += 5;
            player.statLifeMax2 += 10;
            player.fireWalk = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.Chilled] = true;
        }

        public override void AddRecipes() => CreateRecipe()
        .AddIngredient<ValkyrieGoldenShield>()
        .AddIngredient(ItemID.AnkhShield)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
    }

}