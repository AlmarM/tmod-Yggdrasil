using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.NPCs.Vikings;

public class Berserker : YggdrasillNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker");

        Main.npcFrameCount[Type] = 10;

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.width = 30;
        NPC.height = 40;
        NPC.damage = 50;
        NPC.defense = 10;
        NPC.lifeMax = 650;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 3;
        AIType = 213;
        AnimationType = 482;
        NPC.buffImmune[BuffID.Confused] = true;
    }

    /*public override float SpawnChance(NPCSpawnInfo spawnInfo) 
    {
        if(YggdrasilWorld.vikingInvasionUp && !NPC.AnyNPCs(mod.NPCType("Berserker")))
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
        //npcLoot.Add(ItemDropRule.Common(mod.ItemType("VikingDaneAxe"), 100));
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

        /*//Casting slash Projectile while on low life
        float velocity = 7f;
        float speedX = NPC.direction * velocity;
        Vector2 shootPos = NPC.Center;
        if(NPC.life < (NPC.lifeMax * 0.35f))
        {
            if(Main.rand.NextFloat() < .7f)
            {
                //Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType(""), damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(shootPos.X, shootPos.Y, speedX, 0, mod.ProjectileType("WaveSlash"), 20, 5);
            }
        }*/
    }
}