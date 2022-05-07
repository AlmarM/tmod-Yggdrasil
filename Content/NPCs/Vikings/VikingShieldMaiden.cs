using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Yggdrasil.Content.Items.Others;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.Content.Items.Accessories;
using Terraria.GameContent.Bestiary;

namespace Yggdrasil.Content.NPCs.Vikings;

public class VikingShieldMaiden : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Shield Maiden");

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
        NPC.width = 30;
        NPC.height = 40;
        NPC.damage = 30;
        NPC.defense = 10;
        NPC.lifeMax = 130;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0.7f;
        NPC.aiStyle = 3;
        AIType = 28;
        AnimationType = 213;
        NPC.buffImmune[BuffID.Confused] = true;
        NPC.buffImmune[BuffID.Poisoned] = true;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Also part of the bulk force of a Viking army. Forced to travel the world for glory, riches or adventure, these strong and fearless women will stop in front of nothing.")
            });
    }


    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingSword>(), 100));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NorsemanShield>(), 20));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingKey>(), 20));
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