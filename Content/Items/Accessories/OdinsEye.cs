using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Extensions;
using Yggdrasil.ModEffects;

namespace Yggdrasil.Content.Items.Accessories;

public class OdinsEye : YggdrasilItem
{
    [CloneByReference] private readonly DodgeAndHealModEffect _dodgeAndHealEffect = new(10, 0.2f);

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Odin's Eye");
        Tooltip.SetDefault(_dodgeAndHealEffect.EffectDescription);
    }

    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Pink;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 4);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetYggdrasilPlayer().AddModHooks(_dodgeAndHealEffect);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BloodDrops>(10)
        .AddIngredient(ItemID.SoulofSight, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}