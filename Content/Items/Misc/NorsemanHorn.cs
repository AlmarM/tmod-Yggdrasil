using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.NPCs.Vikings;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Nordic.Content.Items.Blocks;
using Yggdrasil.World;

namespace Yggdrasil.Content.Items.Others;

public class NorsemanHorn : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Norseman Horn");
        Tooltip.SetDefault("Might attract unwanted foes when used during the day");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.maxStack = 20;
        Item.value = Item.sellPrice(silver: 1);
        Item.rare = ItemRarityID.Blue;
        Item.useAnimation = 30;
        Item.useTime = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.consumable = true;
        Item.UseSound = SoundID.Item43;
    }

    public override bool CanUseItem(Player player) => !VikingInvasionWorld.vikingInvasion && Main.dayTime &&
                                                      !Main.bloodMoon && !Main.eclipse && player.ZoneOverworldHeight;

    public override bool? UseItem(Player player)
    {
        //Spawns the viking invasion
        Main.NewText("The vikings are here!", 174, 128, 79);
        VikingInvasionWorld.vikingInvasion = true;

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendData(MessageID.WorldData);
        }

        return true;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BloodDrops>(5)
        .AddIngredient<FrostEssence>()
        .AddIngredient<NordicWood>(5)
        .AddTile<DvergrForgeTile>()
        .Register();
}