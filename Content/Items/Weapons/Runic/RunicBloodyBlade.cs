using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.DamageClasses;
using Yggdrasil.Runic;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items.Weapons.Runic;

public class RunicBloodyBlade : RunicItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Runic Bloody Blade");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;
        Item.damage = 15;
        Item.crit = 0;
        Item.knockBack = 4;
        Item.value = Item.buyPrice(0, 0, 25);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BloodDrops>(25)
        .AddRecipeGroup(RecipeGroupID.Wood, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override string GetTooltip()
    {
        string tooltip = base.GetTooltip();
        
        var runePower = string.Format(RuneConfig.RunePowerRequiredLabel, 1);
        var runePowerColored = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, runePower);

        tooltip += $"\n{runePowerColored}: Has 25% chance to heal for 1 on hit";

        return tooltip;
    }

    protected override void AddEffects()
    {
        AddEffect(new FlatRunicDamageEffect(3, 5));
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        var runePlayer = player.GetModPlayer<RunePlayer>();
        var healing = 1;

        if (runePlayer.RunePower >= 4)
        {
            if (player.statLife < player.statLifeMax2)   
            {
                if (Main.rand.NextFloat() < .25f)
                {
                    player.statLife += healing;
                    player.HealEffect(healing);
                }
            }
        }
    }

    
}