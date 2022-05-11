using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.NPCs.Jungle;

public class Gubbe : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gubbe");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.GrayGrunt];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GrayGrunt);
        NPC.damage = 20;
        NPC.defense = 5;
        NPC.lifeMax = 45;
        NPC.value = 200f;
        AIType = NPCID.GrayGrunt;
        AnimationType = NPCID.GrayGrunt;
        NPC.knockBackResist = 0.1f;
        //npc.buffImmune[BuffID.Confused] = true;

    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("The Gubbe is notoriously grumpy and bad-tempered, and prefers to keep himself to himself")
            });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneJungle)
        {
            return SpawnCondition.Overworld.Chance * .8f;
        }

        return 0f;
    }

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BlankRune>(), 5));

    }
}