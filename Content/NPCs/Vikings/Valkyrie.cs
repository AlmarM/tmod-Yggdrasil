using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Misc;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.World;
using Yggdrasil.Content.Projectiles.EnemyProjectile;
using Yggdrasil.Content.Items.Weapons.Magic;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Runemaster.Content.Items.Accessories;

namespace Yggdrasil.Content.NPCs.Vikings;

[AutoloadBossHead]
public class Valkyrie : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Valkyrie");

        Main.npcFrameCount[NPC.type] = 5;
        NPCID.Sets.TrailCacheLength[NPC.type] = 3;
        NPCID.Sets.TrailingMode[NPC.type] = 0;

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 3f
        });

        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[] {
                    BuffID.Frostburn,
                    BuffID.Confused 
				}
        };
        NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
    }

    public override void SetDefaults()
    {
        //NPC.CloneDefaults(NPCID.Parrot);
        NPC.width = 116;
        NPC.height = 100;
        NPC.damage = 75;
        NPC.defense = 30;
        NPC.lifeMax = 3500;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0;
        NPC.aiStyle = 14;
        NPC.noGravity = true;
        NPC.rarity = 2;

        Banner = ModContent.NPCType<Valkyrie>();
        BannerItem = ModContent.ItemType<ValkyrieBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Valkyrie 'chooser of the slain' is one of a host of female figures who guide the souls of deceased Nordic soldiers in one of two paths. Selecting among half of those who die in battle go to Folkvang, Freyja's afterlife, the other half go to Gods hall called Valhalla.")
            });
    }

    int aiTimer;
    bool trailing;

    public IEntitySource GetSource_FromAI { get; private set; }

    public override void AI()
    {
        Lighting.AddLight(NPC.position, .8f, .75f, .1f);

        aiTimer++;
        if (aiTimer == 100 || aiTimer == 480)
        {
            SoundEngine.PlaySound(SoundID.DD2_WyvernDiveDown, NPC.Center);

            var direction = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * Main.rand.Next(6, 9);
            NPC.velocity = direction * 1.2f;
        }

        trailing = aiTimer >= 100 && aiTimer <= 120 || aiTimer >= 480 && aiTimer <= 500;

        if (aiTimer >= 120 && aiTimer <= 300)
        {
            int dust = Dust.NewDust(NPC.Center, NPC.width, NPC.height, DustID.PortalBolt);
            Main.dust[dust].velocity *= -1f;
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2f;

            Vector2 dustSpeed = Vector2.Normalize(new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));
            dustSpeed *= (Main.rand.Next(50, 100) * 0.04f);
            Main.dust[dust].velocity = dustSpeed;
            Main.dust[dust].position = NPC.Center - Vector2.Normalize(dustSpeed) * 34f;
        }

        if (aiTimer == 300)
        {
            SoundEngine.PlaySound(SoundID.DD2_WyvernDiveDown, NPC.Center);

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 direction = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * 13f;
                int damage = Main.expertMode ? 50 : 65;

                int amountOfProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < amountOfProjectiles; ++i)
                {
                    float A = Main.rand.Next(-150, 150) * 0.01f;
                    float B = Main.rand.Next(-150, 150) * 0.01f;
                    Projectile.NewProjectile(GetSource_FromAI, NPC.Center.X, NPC.Center.Y, direction.X + A, direction.Y + B, ModContent.ProjectileType<ValkyrieProjectile>(), damage, 1, Main.myPlayer, 0, 0);
                }
            }
        }


        if (aiTimer >= 500)
            aiTimer = 0;
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.spriteDirection = NPC.direction;

        // This NPC animates with a simple "go from start frame to final frame, and loop back to start frame" rule
        // In this case: First stage: 0-1-2-0-1-2, Second stage: 3-4-5-3-4-5, 5 being "total frame count - 1"
        int startFrame = 0;
        int finalFrame = 4;

        int frameSpeed = 12;
        NPC.frameCounter += 0.5f;
        NPC.frameCounter += NPC.velocity.Length() / 10f; // Make the counter go faster with more movement speed
        if (NPC.frameCounter > frameSpeed)
        {
            NPC.frameCounter = 0;
            NPC.frame.Y += frameHeight;

            if (NPC.frame.Y > finalFrame * frameHeight)
            {
                NPC.frame.Y = startFrame * frameHeight;
            }
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ValkyrieGoldenShield>(), 3));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ValkyrieLightStaff>(), 2));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Raggmunk>(), 100));
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

    public override void OnKill()
    {
        if (VikingInvasionWorld.vikingInvasion)
        VikingInvasionWorld.vikingKilled += 10;
    }
}