using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Yggdrasil.Content.NPCs.Vikings;

// @todo create an actual projectile for this
public class ChaosBallTest : YggdrasilNPC
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

        var position = new Vector2(NPC.position.X, NPC.position.Y + 2f);
        int num136 = Dust.NewDust(position, NPC.width, NPC.height, DustID.Sand, NPC.velocity.X * 0.2f,
            NPC.velocity.Y * 0.2f, 100, default, 1.3f);

        Main.dust[num136].noGravity = true;

        Dust dust = Main.dust[num136];
        dust.velocity *= 0.3f;
        Main.dust[num136].velocity.X -= NPC.velocity.X * 0.2f;
        Main.dust[num136].velocity.Y -= NPC.velocity.Y * 0.2f;

        NPC.rotation += 0.4f * NPC.direction;
        NPC.position -= NPC.netOffset;
    }
}