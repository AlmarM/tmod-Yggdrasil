using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Yggdrasil.Content.Items.Others;
using Yggdrasil.Content.Items.Weapons;

namespace Yggdrasil.Content.NPCs.Vikings;

public class VikingArcher : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Archer");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.GoblinArcher];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GoblinArcher);
        NPC.width = 18;
        NPC.height = 40;
        NPC.damage = 30;
        NPC.defense = 6;
        NPC.lifeMax = 80;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 200f;
        NPC.knockBackResist = 0.2f;
        NPC.aiStyle = 3;
        AIType = NPCID.GoblinArcher;
        AnimationType = NPCID.GoblinArcher;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.ZoneSnow)
        {
            return SpawnCondition.Overworld.Chance * 1f;
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
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingKey>(), 20));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingBow>(), 100));
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