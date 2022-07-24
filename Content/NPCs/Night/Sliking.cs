using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Banners;

namespace Yggdrasil.Content.NPCs.Night;

public class Sliking : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sliking");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Slimer];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.Slimer);
        NPC.damage = 50;
        NPC.defense = 22;
        NPC.lifeMax = 65;
        NPC.value = 200f;
        AIType = NPCID.Slimer;
        AnimationType = NPCID.Slimer;
        //NPC.aiStyle = 3;
        NPC.knockBackResist = 0.3f;

        //Banner = ModContent.NPCType<Sliking>();
        //BannerItem = ModContent.ItemType<VikingBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

				// Sets the description of this NPC that is listed in the bestiary.
				//new FlavorTextBestiaryInfoElement("Lorem Ipsum")
            });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (Main.hardMode)
        {
            return SpawnCondition.OverworldNightMonster.Chance;
        }
        return 0f;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ArmRing>(), 100));
    }

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }
}