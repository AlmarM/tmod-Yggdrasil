using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Misc;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;
using Yggdrasil.World;

namespace Yggdrasil.Content.NPCs.Svartalvheim;

public class Svartalslime : YggdrasilNPC
{
    //Variable used to make sure the NPC keeps spawned during the day befause Fighter AI despawn itself during day
    //Might mess up in multiplayer
    private int _timeLeft;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalslime");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.CorruptSlime];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });

        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[] {
                    BuffID.OnFire
                }
        };
        NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.CorruptSlime);
        NPC.damage = 40;
        NPC.defense = 30;
        NPC.lifeMax = 300;
        NPC.value = 150f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 1;
        NPC.lavaImmune = true;
        AIType = NPCID.CorruptSlime;
        AnimationType = NPCID.CorruptSlime;

        Banner = ModContent.NPCType<Svartalslime>();
        BannerItem = ModContent.ItemType<SvartalslimeBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("There has to be a nasty slime for every single biome in the world isn't it?")
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
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 3, 5));
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        for (var i = 0; i < 10; i++)
        {
            int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemRuby);

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
}