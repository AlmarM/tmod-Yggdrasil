using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class FrostEssence : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frost Essence");
        Tooltip.SetDefault("The essence of a cold dead creature");
        
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(24, 2));
        ItemID.Sets.ItemIconPulse[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Blue;
    }

    public override void PostUpdate()
    {
        Lighting.AddLight(Item.Center, Color.Cyan.ToVector3() * 1f * Main.essScale);
    }
}