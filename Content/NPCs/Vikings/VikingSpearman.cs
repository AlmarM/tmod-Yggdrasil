using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.NPCs.Vikings;

public class VikingSpearman : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Spearman");

        Main.npcFrameCount[Type] = Main.npcFrameCount[213];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GoblinWarrior);
        NPC.width = 34;
        NPC.height = 40;
        NPC.damage = 35;
        NPC.defense = 6;
        NPC.lifeMax = 90;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0.3f;
        NPC.aiStyle = 3;
        AIType = NPCID.GoblinWarrior;
        AnimationType = 213;
    }

    /*public override float SpawnChance(NPCSpawnInfo spawnInfo) 
    {
        if(YggdrasilWorld.vikingInvasionUp)
        {
            return SpawnCondition.Overworld.Chance * 0.5f;
        }
        return 0f;
    }*/

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        //npcLoot.Add(ItemDropRule.Common(mod.ItemType("VikingSpear"), 100));
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        for (var i = 0; i < 10; i++)
        {
            int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            Dust dust = Main.dust[dustIndex];

            dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
            dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
            dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
        }
    }
}