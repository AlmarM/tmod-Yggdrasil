using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace Yggdrasil.NPCs.Vikings
{
	public class Volva : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Völva");
			Main.npcFrameCount[Type] = Main.npcFrameCount[29];
			
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};	
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value); 
		}

		public override void SetDefaults() 
		{
			NPC.CloneDefaults(NPCID.GoblinSorcerer); //goblin sorcerer
			NPC.width = 30;
			NPC.height = 40;
			NPC.damage = 35;
			NPC.defense = 4;
			NPC.lifeMax = 60;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 200f;
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 8;
			AIType = 29;
			AnimationType = 29;
			//Banner = Item.NPCtoBanner(NPCID.Zombie); 
			//BannerItem = Item.BannerToItem(Banner); 
		}

		/* public override float SpawnChance(NPCSpawnInfo spawnInfo) 
		{
			if(YggdrasilWorld.vikingInvasionUp)
			{
				return SpawnCondition.Overworld.Chance * 0.5f;
			}
			return 0f;
		} */
		
		public override void AI()
        {
            NPC.TargetClosest(true);
            NPC.netUpdate = true;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			
			//npcLoot.Add(ItemDropRule.Common(mod.ItemType("VikingDistaff"), 100));
			
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
