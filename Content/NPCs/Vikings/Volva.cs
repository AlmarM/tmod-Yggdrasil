using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

using Yggdrasil.Content.Items.Others;
using Yggdrasil.Content.Items.Weapons.Vikings;

namespace Yggdrasil.Content.NPCs.Vikings;

public class Volva : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Völva");

        Main.npcFrameCount[Type] = Main.npcFrameCount[29];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        //NPC.CloneDefaults(NPCID.GoblinSorcerer); //goblin sorcerer
        NPC.width = 30;
        NPC.height = 40;
        NPC.damage = 20;
        NPC.defense = 4;
        NPC.lifeMax = 60;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 200f;
        NPC.knockBackResist = 0.2f;
        //NPC.aiStyle = 8;
        AIType = 29;
        AnimationType = 29;
        //Banner = Item.NPCtoBanner(NPCID.Zombie); 
        //BannerItem = Item.BannerToItem(Banner);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				//new FlavorTextBestiaryInfoElement("Lorem Ipsum")
            });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneSnow)
        {
            return SpawnCondition.Overworld.Chance * .1f;
        }
        return 0f;
    }

    // @todo encapsulate behavior for composition
    public override void AI() // This is a clone rework of the goblin sorcerer AI
    {
        NPC.TargetClosest();
        NPC.velocity.X *= 0.93f;

        if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
        {
            NPC.velocity.X = 0f;
        }

        if (NPC.ai[0] == 0f)
        {
            NPC.ai[0] = 500f;
        }

        if (NPC.ai[2] != 0f && NPC.ai[3] != 0f) // That part is about the teleport
        {
            NPC.position += NPC.netOffset;
            SoundEngine.PlaySound(SoundID.Item8, NPC.position);
            for (int num69 = 0; num69 < 50; num69++)
            {
                var position = new Vector2(NPC.position.X, NPC.position.Y);

                //Dust left on former spot after teleport
                int num70 = Dust.NewDust(position, NPC.width, NPC.height, DustID.Sand, 0f, 0f, 100, default,
                    Main.rand.Next(1, 3));
                Dust dust = Main.dust[num70];
                dust.velocity *= 3f;
                if (Main.dust[num70].scale > 1f)
                {
                    Main.dust[num70].noGravity = true;
                }
            }

            NPC.position -= NPC.netOffset;
            NPC.position.X = NPC.ai[2] * 16f - NPC.width / 2 + 8f;
            NPC.position.Y = NPC.ai[3] * 16f - NPC.height;
            NPC.netOffset *= 0f;
            NPC.velocity.X = 0f;
            NPC.velocity.Y = 0f;
            NPC.ai[2] = 0f;
            NPC.ai[3] = 0f;

            SoundEngine.PlaySound(SoundID.Item8, NPC.position);

            for (int num78 = 0; num78 < 50; num78++)
            {
                var position = new Vector2(NPC.position.X, NPC.position.Y);

                //Dust explosion after teleport
                int num79 = Dust.NewDust(position, NPC.width, NPC.height, DustID.Sand, 0f, 0f, 100, default,
                    Main.rand.Next(1, 3));
                Dust dust = Main.dust[num79];
                dust.velocity *= 3f;
                if (Main.dust[num79].scale > 1f)
                {
                    Main.dust[num79].noGravity = true;
                }
            }
        }

        NPC.ai[0] += 1f;

        if (NPC.ai[0] == 100f || NPC.ai[0] == 200f || NPC.ai[0] == 300f)
        {
            NPC.ai[1] = 30f;
            NPC.netUpdate = true;
        }

        if (NPC.ai[0] >= 650f &&
            Main.netMode !=
            NetmodeID.MultiplayerClient) // Not sure what this part exacly does but without this, there's no attack
        {
            NPC.ai[0] = 1f;
            int num87 = (int)Main.player[NPC.target].position.X / 16;
            int num88 = (int)Main.player[NPC.target].position.Y / 16;
            int num89 = (int)NPC.position.X / 16;
            int num90 = (int)NPC.position.Y / 16;
            int num91 = 20;
            int num92 = 0;
            bool flag4 = false;
            if (Math.Abs(NPC.position.X - Main.player[NPC.target].position.X) +
                Math.Abs(NPC.position.Y - Main.player[NPC.target].position.Y) > 2000f)
            {
                num92 = 100;
                flag4 = true;
            }

            while (!flag4 && num92 < 100)
            {
                num92++;
                int num93 = Main.rand.Next(num87 - num91, num87 + num91);
                int num94 = Main.rand.Next(num88 - num91, num88 + num91);
                for (int num95 = num94; num95 < num88 + num91; num95++)
                {
                    if ((num95 < num88 - 4 || num95 > num88 + 4 || num93 < num87 - 4 || num93 > num87 + 4) &&
                        (num95 < num90 - 1 || num95 > num90 + 1 || num93 < num89 - 1 || num93 > num89 + 1) &&
                        Main.tile[num93, num95].HasUnactuatedTile)
                    {
                        bool flag5 = true;
                        if ((NPC.type == NPCID.DarkCaster ||
                             (NPC.type >= NPCID.RaggedCaster && NPC.type <= NPCID.DiabolistWhite)) &&
                            !Main.wallDungeon[Main.tile[num93, num95 - 1].WallType])
                        {
                            flag5 = false;
                        }
                        else if (Main.tile[num93, num95 - 1].LiquidType == 1)
                        {
                            flag5 = false;
                        }

                        if (flag5 && Main.tileSolid[Main.tile[num93, num95].TileType] &&
                            !Collision.SolidTiles(num93 - 1, num93 + 1, num95 - 4, num95 - 1))
                        {
                            NPC.ai[1] = 20f;
                            NPC.ai[2] = num93;
                            NPC.ai[3] = num95;
                            flag4 = true;
                            break;
                        }
                    }
                }
            }

            NPC.netUpdate = true;
        }

        if (NPC.ai[1] > 0f) // That's the attack section
        {
            NPC.ai[1] -= 1f;

            if (NPC.ai[1] == 25f)
            {
                SoundEngine.PlaySound(SoundID.Item8, NPC.position);
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X + NPC.width / 2,
                        (int)NPC.position.Y - 8, ModContent.NPCType<ChaosBallTest>());
                }
            }
        }

        /*NPC.position += NPC.netOffset;
        if (Main.rand.Next(5) == 0) // Just the never ending sparkle of dusts
        {
            int num117 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + 2f), NPC.width, NPC.height, 32, //Dust sparkling over the character
                NPC.velocity.X * 0.2f, NPC.velocity.Y * 0.2f, 100, default(Color), 1.5f);
            Main.dust[num117].noGravity = true;
            Main.dust[num117].velocity.X *= 0.5f;
            Main.dust[num117].velocity.Y = -2f;
        }

        NPC.position -= NPC.netOffset;*/
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingDistaff>(), 10));
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