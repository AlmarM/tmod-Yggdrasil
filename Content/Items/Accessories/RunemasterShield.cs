using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class RunemasterShield : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");
            string focusText = TextUtils.GetColoredText(RuneConfig.FocusTooltipColor, "focus");
            string insanityText = TextUtils.GetColoredText(RuneConfig.InsanityTextColor, "insanity");

            DisplayName.SetDefault("Runemaster Shield");
            Tooltip.SetDefault("Grants immunity to knockback" +
                               "\nIncreases defense by 10" +
                               "\nRegenerates life" +
                               "\nIncreases max life by 15" +
                               "\nGrants immunity to most debuffs and fire blocks" +
                               "\nGrants 20% to avoid a fatal blow and heal back to 50% life" +
                               $"\n10% increased {runicText} damage" +
                               $"\nIncreases {insanityText} removed by {focusText} power by 3");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 10);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.statDefense += 10;
            player.lifeRegen += 5;
            player.statLifeMax2 += 15;
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
            player.SetEffect<RunemasterShield>();
            player.GetDamage<RunicDamageClass>() += 0.1f;
            player.GetModPlayer<RunemasterPlayer>().InsanityRemoverValue += 5;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient<VanirShield>()
            .AddIngredient<OdinsEye>()
            .AddIngredient<NorsemanShield>()
            .AddIngredient<TrueHeroFragment>()
            .AddIngredient(ItemID.LunarBar, 5) 
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }

}