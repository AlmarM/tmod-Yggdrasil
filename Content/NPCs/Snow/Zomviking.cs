using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.NPCs.Snow;

public class Zomviking : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zomviking");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.Zombie);
        NPC.damage = 20;
        NPC.defense = 9;
        NPC.lifeMax = 80;
        NPC.value = 200f;
        AIType = NPCID.Zombie;
        AnimationType = NPCID.Zombie;
        NPC.aiStyle = 3;
        NPC.knockBackResist = 0.55f;

        Banner = Item.NPCtoBanner(NPCID.Zombie);
        BannerItem = Item.BannerToItem(Banner);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return SpawnCondition.OverworldNightMonster.Chance * 0.7f;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ArmRing>(), 100));
    }

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }
}