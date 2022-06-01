using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.NPCs.Vikings;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Others;

public class NorsemanHorn : YggdrasilItem
{

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Norseman Horn");
        Tooltip.SetDefault("Use in the snow to summon a Berserker");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.maxStack = 20;
        Item.value = 100;
        Item.rare = ItemRarityID.Blue;
        Item.useAnimation = 30;
        Item.useTime = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.consumable = true;
        Item.UseSound = SoundID.Item43;
    }

    public override bool CanUseItem(Player player)
    {
        // If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss.
        // If you want more constraints for the summon item, combine them as boolean expressions:
        //    return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<MinionBossBody>()); would mean "not daytime and no MinionBossBody currently alive"
        return !NPC.AnyNPCs(ModContent.NPCType<Berserker>()) && player.ZoneSnow;
    }

    public override bool? UseItem(Player player)
    {
        if (player.ZoneSnow)
        {
            NPC.NewNPC(null, (int)player.position.X, (int)player.position.Y - 200, ModContent.NPCType<Berserker>());
            SoundEngine.PlaySound(SoundID.Thunder, player.position);
        }
        return true;
    }

    public override void AddRecipes() => CreateRecipe()
         .AddIngredient<BloodDrops>(5)
         .AddIngredient<FrostEssence>()
         .AddIngredient(ItemID.BorealWood, 10)
         .AddTile<DvergrForgeTile>()
         .Register();
}