using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Items.Others;

namespace Yggdrasil.NPCs.Snow
{
	public class Draugr : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Draugr");
			Main.npcFrameCount[Type] = Main.npcFrameCount[524];
		}

		public override void SetDefaults() 
		{
			NPC.CloneDefaults(524);
			NPC.damage = 25;
			NPC.defense = 5;
			NPC.lifeMax = 80;
			NPC.value = 200f;
			AIType = 524;
			AnimationType = 524;
			NPC.knockBackResist = 0.2f;
			//npc.buffImmune[BuffID.Confused] = true;
			NPC.buffImmune[BuffID.Frostburn] = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) 
		{
			if(spawnInfo.player.ZoneSnow)
			{
				return SpawnCondition.Overworld.Chance * 0.5f;
			}
			return 0f;
		}
		
		public override void AI()
        {
			NPC.TargetClosest(true);
			NPC.netUpdate = true;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit) 
		{
			player.AddBuff(BuffID.Frostburn, 180, true);
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostEssence>(), 2));

		}

		public override void HitEffect(int hitDirection, double damage) 
		{
			for (int i = 0; i < 3; i++) {
				int dustType = 226;
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}
