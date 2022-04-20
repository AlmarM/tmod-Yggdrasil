using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Yggdrasil.NPCs.Vikings
{
	public class ChaosBallTest	: ModNPC
	{

		public override void SetDefaults() 
		{
			//NPC.CloneDefaults(30); //ChaosBall

			
			NPC.width = 16;
			NPC.height = 16;
			NPC.aiStyle = 9;
			NPC.damage = 30;
			NPC.defense = 0;
			NPC.lifeMax = 1;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.knockBackResist = 0f;
		}

		
		public override void AI()
        {
            NPC.EncourageDespawn(100);
            
            NPC.position += NPC.netOffset;
            
            NPC.alpha = 255;
                    
			int num136 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + 2f), NPC.width, NPC.height, 32, NPC.velocity.X * 0.2f, NPC.velocity.Y * 0.2f, 100, default(Color), 1.3f);
			Main.dust[num136].noGravity = true;
			Dust dust = Main.dust[num136];
			dust.velocity *= 0.3f;
			Main.dust[num136].velocity.X -= NPC.velocity.X * 0.2f;
			Main.dust[num136].velocity.Y -= NPC.velocity.Y * 0.2f;
		            
            NPC.rotation += 0.4f * (float)NPC.direction;
            NPC.position -= NPC.netOffset;
            return;
		}


		
	}
}
