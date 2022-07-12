using Terraria.DataStructures;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Others;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.Content.Players;
using Yggdrasil.World;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.NPCs.Svartalvheim;

public class DwarfSpirit : YggdrasilNPC
{
    //Variable used to make sure the NPC keeps spawned during the day befause Fighter AI despawn itself during day
    //Might mess up in multiplayer
    private int _timeLeft;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dwarf Spirit");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Wraith];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });

        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[] {
                    BuffID.Confused
                }
        };
        NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
    }

    public override void SetDefaults()
    {
        //NPC.CloneDefaults(NPCID.GoblinWarrior);
        NPC.width = 28;
        NPC.height = 38;
        NPC.damage = 60;
        NPC.defense = 20;
        NPC.lifeMax = 350;
        NPC.HitSound = SoundID.NPCHit3;
        NPC.DeathSound = SoundID.NPCDeath6;
        NPC.value = 150f;
        NPC.knockBackResist = 0;
        NPC.aiStyle = 22;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        AIType = NPCID.Wraith;
        AnimationType = NPCID.Wraith;

        //Banner = ModContent.NPCType<VikingSwordMan>();
        //BannerItem = ModContent.ItemType<VikingBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("The dwarves are skilled craftsmen, and they have crafted some of the best objects in the world. They live inside stones and mountains, in a place called Svartalfheim.")
            });
    }

    //Setting the variable in PreAI to make sure the NPC keeps spawned during the day
    //Might mess up in multiplayer
    public override bool PreAI()
    {
        _timeLeft = NPC.timeLeft;

        return base.PreAI();
    }

    public override void AI()
    {
        NPC.timeLeft = _timeLeft;  

        NPC.TargetClosest();
        NPC.netUpdate = true;

        Lighting.AddLight(NPC.position, .7f, .7f, .7f);
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingKey>(), 50));
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        for (var i = 0; i < 10; i++)
        {
            int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Electric);

            Dust dust = Main.dust[dustIndex];
            dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
            dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
            dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
        }
    }

    public override void OnHitPlayer(Player player, int damage, bool crit)
    {
        player.AddBuff(BuffID.Ichor, TimeUtils.SecondsToTicks(3));
    }

    public override void OnKill()
    {
        for (int i = 0; i < 10; i++)
        {
            int num = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Electric, 0f, -2f, 0, default, 2f);
            Main.dust[num].noGravity = true;
            Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
            Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
            if (Main.dust[num].position != NPC.Center)
            {
                Main.dust[num].velocity = NPC.DirectionTo(Main.dust[num].position) * 1.5f;
            }
        }
    }
}