using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace Yggdrasil.NPCs.Vikings
{
	public class VikingShieldMaiden : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Viking Shield Maiden");
			Main.npcFrameCount[Type] = Main.npcFrameCount[213];
			
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};	
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value); 
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
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = 28;
			AnimationType = 213;
			NPC.buffImmune[BuffID.Confused] = true;
			NPC.buffImmune[BuffID.Poisoned] = true;
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
            NPC.TargetClosest(true);
            NPC.netUpdate = true;
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			
			//npcLoot.Add(ItemDropRule.Common(mod.ItemType("VikingSword"), 100));
			//npcLoot.Add(ItemDropRule.Common(mod.ItemType("NorsemenShield"), 100));
		}
		
		
		public override void HitEffect(int hitDirection, double damage) 
		{
			for (int i = 0; i < 10; i++) {
				int dustType = 5;
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}
